using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Json.Schema;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>Discovers messages, exports documented JSON schemas and recognizes/parses incoming JSON.</summary>
/// <remarks>Uses the compiled model's serialization contract and embedded XML documentation. No MCP host is required.</remarks>
public sealed class MessageCatalog
{
    private const string ModelNamespace = "Skyware.Lis.EventsModel.";
    private readonly ModelDocumentation documentation = new();
    private readonly JsonSerializerOptions serializer;
    private readonly Type[] messageTypes;
    private readonly Dictionary<string, Type> discriminators;
    private readonly string? discriminatorProperty;
    private readonly int maxBytes;
    private readonly int maxDepth;
    private readonly ConcurrentDictionary<Type, SchemaEntry> schemas = new();

    /// <summary>Creates a reusable catalog; options are copied and cannot subsequently alter the catalog.</summary>
    public MessageCatalog(MessageCatalogOptions? options = null)
    {
        options ??= new();
        if (options.MaxMessageBytes <= 0 || options.MaxDepth <= 0)
            throw new ArgumentOutOfRangeException(nameof(options), "Input limits must be positive.");
        maxBytes = options.MaxMessageBytes;
        maxDepth = options.MaxDepth;
        discriminatorProperty = options.DiscriminatorPropertyName;
        if (discriminatorProperty is not null && string.IsNullOrWhiteSpace(discriminatorProperty))
            throw new ArgumentException("Discriminator property must not be empty.", nameof(options));
        if (discriminatorProperty is null && options.DiscriminatorMappings.Count > 0)
            throw new ArgumentException("Discriminator mappings require a property name.", nameof(options));
        serializer = new JsonSerializerOptions
        {
            PropertyNamingPolicy = options.PropertyNamingPolicy,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
            MaxDepth = maxDepth
        };
        serializer.MakeReadOnly();
        messageTypes = typeof(BaseMessage).Assembly.GetExportedTypes()
            .Where(t => !t.IsAbstract && typeof(BaseMessage).IsAssignableFrom(t))
            .OrderBy(TypeId, StringComparer.Ordinal).ToArray();
        discriminators = options.DiscriminatorMappings.ToDictionary(x => x.Key, x => ResolveMessageType(x.Value), StringComparer.Ordinal);
        if (discriminatorProperty is not null && messageTypes.Any(t =>
                serializer.GetTypeInfo(t).Properties.Any(p => p.Name == discriminatorProperty)))
            throw new ArgumentException("Discriminator conflicts with a model property.", nameof(options));
    }

    /// <summary>Returns every concrete BaseMessage subtype, sorted by its namespace-qualified model ID.</summary>
    public IReadOnlyList<MessageTypeInfo> ListMessageTypes() => messageTypes.Select(DescribeType).ToArray();

    /// <summary>Returns a standalone schema, descriptions and a synthetic example for a message type.</summary>
    /// <param name="type">Relative model ID, full CLR name, or unambiguous simple name.</param>
    public MessageDescription DescribeMessage(string type) => Describe(ResolveMessageType(type));

    /// <summary>Exports a standalone JSON Schema 2020-12 document for any public model object or enum.</summary>
    public JsonObject GetSchema<T>() => GetSchema(typeof(T));

    /// <summary>Exports a standalone schema. Only types from the model assembly are accepted.</summary>
    public JsonObject GetSchema(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        if (type.Assembly != typeof(BaseMessage).Assembly || !type.IsPublic || (!type.IsClass && !type.IsEnum))
            throw new ArgumentException("Type must be a public model class or enum.", nameof(type));
        return (JsonObject)GetEntry(type).Schema.DeepClone();
    }

    /// <summary>Validates JSON and returns every compatible type with documentation; never ranks or guesses.</summary>
    public MessageExplanation ExplainMessage(string json) => Explain(json, null);

    /// <summary>Deserializes only when exactly one type is identified, or validates an explicitly supplied type.</summary>
    /// <exception cref="MessageParseException">Invalid, unknown or ambiguous message.</exception>
    public BaseMessage ParseMessage(string json, string? type = null)
    {
        var explanation = Explain(json, type is null ? null : ResolveMessageType(type));
        if (explanation.Status != MessageMatchStatus.Matched) throw new MessageParseException(explanation);
        var selected = ResolveMessageType(explanation.Candidates[0].MessageType.Type);
        return Deserialize(explanation.Message!.Value, selected);
    }

    private MessageExplanation Explain(string json, Type? requestedType)
    {
        ArgumentNullException.ThrowIfNull(json);
        JsonElement message;
        try
        {
            if (Encoding.UTF8.GetByteCount(json) > maxBytes) throw new JsonException("Message exceeds the configured UTF-8 size limit.");
            using var document = JsonDocument.Parse(json, new JsonDocumentOptions { MaxDepth = maxDepth });
            RejectDuplicateProperties(document.RootElement);
            message = document.RootElement.Clone();
        }
        catch (JsonException e)
        {
            return new(MessageMatchStatus.InvalidJson, null, [], [new(null, e.Path ?? "", e.Message)]);
        }
        if (message.ValueKind != JsonValueKind.Object)
            return new(MessageMatchStatus.InvalidMessage, message, [], [new(null, "", "A message must be a JSON object.")]);

        Type[] selected = requestedType is null ? messageTypes : [requestedType];
        var explicitType = requestedType is not null;
        if (discriminatorProperty is not null && message.TryGetProperty(discriminatorProperty, out var discriminator))
        {
            if (discriminator.ValueKind != JsonValueKind.String || !discriminators.TryGetValue(discriminator.GetString()!, out var resolved))
                return new(MessageMatchStatus.UnknownDiscriminator, message, [],
                    [new(null, "/" + Escape(discriminatorProperty), "Discriminator must be a registered string value.")]);
            if (requestedType is not null && requestedType != resolved)
                return new(MessageMatchStatus.InvalidMessage, message, [],
                    [new(TypeId(requestedType), "/" + Escape(discriminatorProperty), "Discriminator conflicts with the requested type.")]);
            selected = [resolved];
            explicitType = true;
        }

        var matches = new List<MessageDescription>();
        var errors = new List<ValidationIssue>();
        foreach (var candidate in selected)
        {
            var result = GetEntry(candidate).Validator.Evaluate(message, new EvaluationOptions
            {
                OutputFormat = OutputFormat.List,
                // JSON Schema's format is an annotation by default. The serializer below validates
                // dates using the actual .NET wire contract, including DateTime without an offset.
                RequireFormatValidation = false
            });
            if (!result.IsValid)
            {
                CollectErrors(result, TypeId(candidate), errors);
                continue;
            }
            try
            {
                // The serializer additionally checks CLR constraints, e.g. Int32 overflow.
                Deserialize(message, candidate);
                matches.Add(Describe(candidate));
            }
            catch (JsonException e) { errors.Add(new(TypeId(candidate), e.Path ?? "", e.Message)); }
        }
        var status = matches.Count switch
        {
            0 => explicitType ? MessageMatchStatus.InvalidMessage : MessageMatchStatus.NoMatch,
            1 => MessageMatchStatus.Matched,
            _ => MessageMatchStatus.Ambiguous
        };
        return new(status, message, matches.ToArray(), matches.Count == 0 ? errors.ToArray() : []);
    }

    private BaseMessage Deserialize(JsonElement message, Type type)
    {
        if (discriminatorProperty is not null && message.TryGetProperty(discriminatorProperty, out _))
        {
            var payload = JsonNode.Parse(message.GetRawText())!.AsObject();
            payload.Remove(discriminatorProperty);
            return (BaseMessage)payload.Deserialize(type, serializer)!;
        }
        return (BaseMessage)message.Deserialize(type, serializer)!;
    }

    private SchemaEntry GetEntry(Type type) => schemas.GetOrAdd(type, BuildSchema);

    private SchemaEntry BuildSchema(Type type)
    {
        var schema = serializer.GetJsonSchemaAsNode(type, new JsonSchemaExporterOptions
        {
            TransformSchemaNode = (context, node) =>
            {
                if (node is not JsonObject obj) return node;
                var member = context.PropertyInfo?.AttributeProvider as MemberInfo ?? context.TypeInfo.Type;
                var description = documentation.Describe(member);
                if (description.Length > 0) obj["description"] = description;
                if (context.PropertyInfo?.Get is not null && context.PropertyInfo.Set is null) obj["readOnly"] = true;
                var enumType = Nullable.GetUnderlyingType(context.TypeInfo.Type) ?? context.TypeInfo.Type;
                if (enumType.IsEnum)
                {
                    var values = new JsonArray();
                    foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
                        values.Add(new JsonObject
                        {
                            ["name"] = field.Name,
                            ["value"] = JsonSerializer.SerializeToNode(field.GetValue(null), enumType, serializer),
                            ["description"] = documentation.Describe(field)
                        });
                    obj["x-enumDescriptions"] = values;
                }
                return obj;
            }
        }).AsObject();
        schema["$schema"] = "https://json-schema.org/draft/2020-12/schema";
        schema["title"] = TypeId(type);
        if (typeof(BaseMessage).IsAssignableFrom(type) && !type.IsAbstract)
        {
            schema["type"] = "object"; // Messages themselves cannot be null; nested nullability is preserved.
            if (discriminatorProperty is not null)
            {
                var values = discriminators.Where(x => x.Value == type).Select(x => x.Key).Order(StringComparer.Ordinal).ToArray();
                if (values.Length > 0)
                    schema["properties"]!.AsObject()[discriminatorProperty] = new JsonObject
                    {
                        ["type"] = "string",
                        ["enum"] = new JsonArray(values.Select(x => (JsonNode?)JsonValue.Create(x)).ToArray()),
                        ["description"] = "Explicit message type discriminator configured by the consumer."
                    };
            }
        }
        var validator = JsonSchema.FromText(schema.ToJsonString(), new BuildOptions
        {
            Dialect = Dialect.Draft202012,
            SchemaRegistry = new()
        });
        return new(schema, validator);
    }

    private MessageDescription Describe(Type type)
    {
        var schema = GetSchema(type);
        var example = SchemaExample.Create(schema);
        return new(DescribeType(type), schema,
            [new("Synthetic structural example generated from the schema; values are illustrative, not clinical guidance.", example)]);
    }

    private MessageTypeInfo DescribeType(Type type) => new(TypeId(type), type.FullName!, documentation.Describe(type),
        ((BaseMessage)Activator.CreateInstance(type)!).DefaultAddress);

    private Type ResolveMessageType(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        var matches = messageTypes.Where(t => TypeId(t) == name || t.FullName == name || t.Name == name).ToArray();
        return matches.Length switch
        {
            1 => matches[0],
            0 => throw new ArgumentException($"Unknown message type '{name}'. Use ListMessageTypes().", nameof(name)),
            _ => throw new ArgumentException($"Ambiguous type name '{name}'. Use a namespace-qualified model ID.", nameof(name))
        };
    }

    private static string TypeId(Type type) => type.FullName![ModelNamespace.Length..];
    private static string Escape(string value) => value.Replace("~", "~0").Replace("/", "~1");

    private static void RejectDuplicateProperties(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            var names = new HashSet<string>(StringComparer.Ordinal);
            foreach (var property in element.EnumerateObject())
            {
                if (!names.Add(property.Name)) throw new JsonException($"Duplicate JSON property '{property.Name}'.");
                RejectDuplicateProperties(property.Value);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
            foreach (var item in element.EnumerateArray()) RejectDuplicateProperties(item);
    }

    private static void CollectErrors(EvaluationResults result, string type, List<ValidationIssue> errors)
    {
        if (result.IsValid) return;
        if (result.Errors is not null)
            foreach (var error in result.Errors.Values) errors.Add(new(type, result.InstanceLocation.ToString(), error));
        if (result.Details is not null)
            foreach (var child in result.Details) CollectErrors(child, type, errors);
    }

    private sealed record SchemaEntry(JsonObject Schema, JsonSchema Validator);
}
