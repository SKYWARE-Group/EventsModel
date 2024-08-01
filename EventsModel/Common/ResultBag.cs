namespace Skyware.Lis.EventsModel.Common;

/// <summary>
/// Represent result values bag.
/// </summary>
public class ResultBag
{

    /// <summary>
    /// Result as text.
    /// </summary>
    public string Result { get; set; } = string.Empty;

    /// <summary>
    /// Optional, prefix such as "&gt;", "&lt;&lt;", etc.
    /// </summary>
    public string NumericPrefix { get; set; } = null;

    /// <summary>
    /// Optional, decimal result.
    /// </summary>
    public decimal? NumericResult { get; set; } = null;

}
