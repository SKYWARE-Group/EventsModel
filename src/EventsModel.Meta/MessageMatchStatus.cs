using System.Text.Json.Serialization;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// Recognition outcome. Matched means one compatible type, not proof of the producer's intent.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<MessageMatchStatus>))]
public enum MessageMatchStatus
{
    /// <summary>
    /// Exactly one type is compatible.
    /// </summary>
    Matched,
    /// <summary>
    /// Multiple types are compatible; no type is selected.
    /// </summary>
    Ambiguous,
    /// <summary>
    /// No type is compatible.
    /// </summary>
    NoMatch,
    /// <summary>
    /// Malformed JSON, duplicate properties, excessive size or excessive nesting.
    /// </summary>
    InvalidJson,
    /// <summary>
    /// JSON is not an object, or does not satisfy the explicitly selected type.
    /// </summary>
    InvalidMessage,
    /// <summary>
    /// A configured discriminator is present but its value is not registered.
    /// </summary>
    UnknownDiscriminator
}
