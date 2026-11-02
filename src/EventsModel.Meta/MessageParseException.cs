namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// Thrown when parsing cannot select exactly one valid message type.
/// </summary>
public sealed class MessageParseException : Exception
{
    /// <summary>
    /// The recognition result, including candidates and validation errors.
    /// </summary>
    public MessageExplanation Explanation { get; }

    /// <summary>
    /// Creates an exception preserving the recognition result.
    /// </summary>
    public MessageParseException(MessageExplanation explanation)
        : base($"Message cannot be parsed: {explanation.Status}.") => Explanation = explanation;
}
