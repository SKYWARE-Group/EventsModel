using System.Text.Json.Nodes;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// An explicitly synthetic, schema-derived example; not a real clinical event.
/// </summary>
public sealed record MessageExample(string Description, JsonNode Value);
