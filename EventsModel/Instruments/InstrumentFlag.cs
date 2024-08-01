namespace Skyware.Lis.EventsModel.Instruments;


/// <summary>
/// Represents instrument's flag of the result, such as 'High", "Low", etc.
/// </summary>
public class InstrumentFlag
{

    /// <summary>
    /// Code of the flag as it is transmitted from the instrument
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Resolved value
    /// </summary>
    public string Value { get; set; }

}
