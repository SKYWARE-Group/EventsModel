namespace Skyware.Lis.EventsModel.Common;


/// <summary>
/// Laboratory examination - test or panel.
/// </summary>
public class Examination
{

    /// <summary>
    /// Primary key in LIS iLab.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Code (usually LOINC) of the examination.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Name of the examination
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// True if the examination is a panel (profile).
    /// </summary>
    public bool? IsPanel { get; set; }

    /// <summary>
    /// Type of the event.
    /// </summary>
    public string EventType { get; set; }

}
