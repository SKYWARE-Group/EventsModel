using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>Options for the wire format understood by a catalog. Defaults match System.Text.Json.</summary>
public sealed class MessageCatalogOptions
{
    /// <summary>Property naming policy; null preserves the model's PascalCase property names.</summary>
    public JsonNamingPolicy? PropertyNamingPolicy { get; init; }

    /// <summary>Optional top-level string discriminator, e.g. "$type". No discriminator is assumed by default.</summary>
    public string? DiscriminatorPropertyName { get; init; }

    /// <summary>Maps discriminator values to catalog type IDs. Values are never resolved through Type.GetType.</summary>
    public IReadOnlyDictionary<string, string> DiscriminatorMappings { get; init; } = new Dictionary<string, string>();

    /// <summary>Maximum UTF-8 input size. Defaults to one MiB.</summary>
    public int MaxMessageBytes { get; init; } = 1024 * 1024;

    /// <summary>Maximum input nesting depth. Defaults to 64.</summary>
    public int MaxDepth { get; init; } = 64;
}

/// <summary>Discoverable message type, its XML documentation and default broker address.</summary>
public sealed record MessageTypeInfo(string Type, string ClrType, string Description, string DefaultAddress);

/// <summary>An explicitly synthetic, schema-derived example; not a real clinical event.</summary>
public sealed record MessageExample(string Description, JsonNode Value);

/// <summary>Self-contained description suitable for a describe_message MCP tool.</summary>
public sealed record MessageDescription(MessageTypeInfo MessageType, JsonObject Schema, IReadOnlyList<MessageExample> Examples);

/// <summary>A validation error, optionally associated with a candidate and a JSON Pointer.</summary>
public sealed record ValidationIssue(string? Type, string Path, string Message);

/// <summary>Recognition outcome. Matched means one compatible type, not proof of the producer's intent.</summary>
[JsonConverter(typeof(JsonStringEnumConverter<MessageMatchStatus>))]
public enum MessageMatchStatus
{
    /// <summary>Exactly one type is compatible.</summary>
    Matched,
    /// <summary>Multiple types are compatible; no type is selected.</summary>
    Ambiguous,
    /// <summary>No type is compatible.</summary>
    NoMatch,
    /// <summary>Malformed JSON, duplicate properties, excessive size or excessive nesting.</summary>
    InvalidJson,
    /// <summary>JSON is not an object, or does not satisfy the explicitly selected type.</summary>
    InvalidMessage,
    /// <summary>A configured discriminator is present but its value is not registered.</summary>
    UnknownDiscriminator
}

/// <summary>Original parsed JSON and documentation for every compatible candidate, without guessing.</summary>
public sealed record MessageExplanation(
    MessageMatchStatus Status,
    JsonElement? Message,
    IReadOnlyList<MessageDescription> Candidates,
    IReadOnlyList<ValidationIssue> Errors);

/// <summary>Thrown when parsing cannot select exactly one valid message type.</summary>
public sealed class MessageParseException : Exception
{
    /// <summary>The recognition result, including candidates and validation errors.</summary>
    public MessageExplanation Explanation { get; }

    /// <summary>Creates an exception preserving the recognition result.</summary>
    public MessageParseException(MessageExplanation explanation)
        : base($"Message cannot be parsed: {explanation.Status}.") => Explanation = explanation;
}
