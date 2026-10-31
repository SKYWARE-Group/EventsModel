using Skyware.Lis.EventsModel.Common;

namespace Skyware.Lis.EventsModel.Results;

/// <summary>
/// Test
/// </summary>
public class Test : TestBase
{

    /// <summary>
    /// LOINC code.
    /// </summary>
    /// <remarks>
    /// It's laboratory's responsibility to comply with LOINC.
    /// Some laboratories may use other coding systems or private codes as well.
    /// </remarks>
    public string LoincCode { get; set; }

}
