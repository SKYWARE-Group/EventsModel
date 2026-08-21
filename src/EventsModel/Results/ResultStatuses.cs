namespace Skyware.Lis.EventsModel.Results;

/// <summary>
/// The statuses of a single test (assay) result entry.
/// </summary>
public enum ResultStatuses
{

    /// <summary>
    /// Unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Pending result, hasn't value.
    /// </summary>
    Pending = 1,

    /// <summary>
    /// Technically validated, but not medically validated, therefore not ready for reporting.
    /// </summary>
    Preliminary = 2,

    /// <summary>
    /// Validated, final.
    /// </summary>
    Validated = 3,

    /// <summary>
    /// Result overrides already validated one.
    /// </summary>
    Corrected = 4,

}
