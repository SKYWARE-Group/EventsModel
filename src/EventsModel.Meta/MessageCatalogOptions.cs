using System.Text.Json;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// Options for the wire format understood by a catalog. Defaults match System.Text.Json.
/// </summary>
public sealed class MessageCatalogOptions
{
    /// <summary>
    /// Property naming policy; null preserves the model's PascalCase property names.
    /// </summary>
    public JsonNamingPolicy? PropertyNamingPolicy { get; init; }

    /// <summary>
    /// Optional top-level string discriminator, e.g. "$type". No discriminator is assumed by default.
    /// </summary>
    public string? DiscriminatorPropertyName { get; init; }

    /// <summary>
    /// Maps discriminator values to catalog type IDs. Values are never resolved through Type.GetType.
    /// </summary>
    public IReadOnlyDictionary<string, string> DiscriminatorMappings { get; init; } = new Dictionary<string, string>();

    /// <summary>
    /// Maximum UTF-8 input size. Defaults to one MiB.
    /// </summary>
    public int MaxMessageBytes { get; init; } = 1024 * 1024;

    /// <summary>
    /// Maximum input nesting depth. Defaults to 64.
    /// </summary>
    public int MaxDepth { get; init; } = 64;
}
