namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// A validation error, optionally associated with a candidate and a JSON Pointer.
/// </summary>
public sealed record ValidationIssue(string? Type, string Path, string Message);
