using System.Text.Json.Nodes;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// Self-contained description suitable for a describe_message MCP tool.
/// </summary>
public sealed record MessageDescription(MessageTypeInfo MessageType, JsonObject Schema, IReadOnlyList<MessageExample> Examples);
