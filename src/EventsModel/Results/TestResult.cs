using System;

namespace Skyware.Lis.EventsModel.Results;

/// <summary>
/// Represent a result for single test (assay)
/// </summary>
public class TestResult
{

    /// <summary>
    /// PK in iLab database.
    /// </summary>
    public int? ItemId { get; set; }

    /// <summary>
    /// Test
    /// </summary>
    public Test Test { get; set; }

    /// <summary>
    /// The new result states.
    /// </summary>
    public ResultStatuses Status { get; set; } = ResultStatuses.Unknown;

    /// <summary>
    /// Result as text.
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// Optional, prefix such as "&gt;", "&lt;&lt;", etc.
    /// </summary>
    public string NumericPrefix { get; set; }

    /// <summary>
    /// Optional, decimal result.
    /// </summary>
    public decimal? NumericResult { get; set; }

    /// <summary>
    /// Flag, according to reference range (1-7, 10, 11).
    /// </summary>
    /// <remarks>
    /// 1=ultra low, 2=very low, 3=low, 5=high, 6=very high, 7=ultra high, 10=star.
    /// 4=no flag. Null means the flag is not calculated.
    /// </remarks>
    public byte? FlagLevel { get; set; } // No flag, see iLab

    /// <summary>
    /// UTC date/time result has been obtained from the instrument.
    /// </summary>
    public DateTime ResultTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Local time of the result.
    /// </summary>
    public DateTime LocalResultTime => ResultTime.ToLocalTime();

}
