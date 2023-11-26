// Ignore Spelling: bg nra pid

namespace Skyware.Lis.EventsModel.BgNra;

/// <summary>
/// Occurs when Health Insurance (Bulgaria, NRA) is checked 
/// </summary>
public class InsuranceCheck : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://bg-nra/insurance-checks";

    /// <summary>
    /// Visit to which the patient is associated in the check
    /// </summary>
    public int VisitId { get; set; }

    /// <summary>
    /// Patient identifier type, according to LIS iLab
    /// </summary>
    public int PidType { get; set; }

    /// <summary>
    /// Patient identifier
    /// </summary>
    public string Pid { get; set; }

    /// <summary>
    /// Zero means insured, any non zero values indicates problem with insurance
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Textual representation of a status
    /// </summary>
    public string StatusText { get; set; }

    /// <summary>
    /// Base64 encoded answer from the NRA service
    /// </summary>
    public string OriginalFile { get; set; }

}
