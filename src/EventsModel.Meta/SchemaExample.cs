using System.Text.Json.Nodes;

namespace Skyware.Lis.EventsModel.Meta;

internal static class SchemaExample
{
    public static JsonNode Create(JsonObject schema) => Build(schema, schema, 0)
        ?? throw new InvalidOperationException("A message example must be an object.");

    private static JsonNode? Build(JsonNode schema, JsonNode root, int depth)
    {
        if (depth > 32) throw new InvalidOperationException("Example schema exceeds supported nesting depth.");
        if (schema is not JsonObject obj) return null;
        if (obj["$ref"] is JsonValue reference)
        {
            var pointer = reference.GetValue<string>();
            if (!pointer.StartsWith('#')) throw new InvalidOperationException("Only local schema references are supported.");
            var target = root;
            foreach (var segment in pointer[1..].Split('/', StringSplitOptions.RemoveEmptyEntries))
            {
                var key = Uri.UnescapeDataString(segment).Replace("~1", "/").Replace("~0", "~");
                target = target is JsonArray array ? array[int.Parse(key)]! : target[key]!;
            }
            return Build(target, root, depth + 1);
        }
        if (obj["const"] is { } constant) return constant.DeepClone();
        if (obj["enum"] is JsonArray values) return values.FirstOrDefault(x => x is not null)?.DeepClone();
        if ((obj["anyOf"] ?? obj["oneOf"]) is JsonArray alternatives)
        {
            var branch = alternatives.FirstOrDefault(x => x is JsonObject && x["type"]?.ToJsonString() != "\"null\"");
            if (branch is not null) return Build(branch, root, depth + 1);
        }
        var type = obj["type"] is JsonArray types
            ? types.Select(x => x!.GetValue<string>()).FirstOrDefault(x => x != "null")
            : obj["type"]?.GetValue<string>();
        switch (type)
        {
            case "object":
                var result = new JsonObject();
                if (obj["properties"] is JsonObject properties)
                    foreach (var property in properties) result[property.Key] = Build(property.Value!, root, depth + 1);
                return result;
            case "array":
                return obj["items"] is { } items ? new JsonArray(Build(items, root, depth + 1)) : new JsonArray();
            case "integer":
            case "number": return JsonValue.Create(0);
            case "boolean": return JsonValue.Create(false);
            case "string": return JsonValue.Create(obj["format"]?.GetValue<string>() switch
            {
                "date-time" => "2000-01-01T00:00:00Z",
                "date" => "2000-01-01",
                "time" => "00:00:00Z",
                "uuid" => "00000000-0000-0000-0000-000000000000",
                "duration" => "P0D",
                _ => "example"
            });
            default: return null;
        }
    }
}
