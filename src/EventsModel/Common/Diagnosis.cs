namespace Skyware.Lis.EventsModel.Common;


/// <summary>
/// ICD-10 encoded diagnosis
/// </summary>
public class Diagnosis
{

    /// <summary>
    /// Code of diagnosis, dagger one in case of pair encoded diagnosis
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Supplemental code in case of diagnosis pair, AKA asterisk code
    /// </summary>
    public string SecondaryCode { get; set; }

}
