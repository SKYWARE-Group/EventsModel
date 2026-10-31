using System.Text.Json.Nodes;
using Json.Schema;

namespace Skyware.Lis.EventsModel.Meta;

internal sealed record SchemaEntry(JsonObject Schema, JsonSchema Validator);
