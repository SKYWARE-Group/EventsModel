using System.Text.Json;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// Original parsed JSON and documentation for every compatible candidate, without guessing.
/// </summary>
public sealed record MessageExplanation(
    MessageMatchStatus Status,
    JsonElement? Message,
    IReadOnlyList<MessageDescription> Candidates,
    IReadOnlyList<ValidationIssue> Errors);
