namespace Skyware.Lis.EventsModel.Instruments;

/// <summary>
/// Occurs when single test result is approved and sent to LIS.
/// </summary>
/// <remarks>
/// This event is emitted from communication applications (Iris, iLink, etc.) 
/// upon approval of a single test result.
/// </remarks>
public class ResultApproval : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://instruments/result-approvals";

    /// <summary>
    /// <see cref="Instrument"/> from which the results are received.
    /// </summary>
    public Instrument Instrument { get; set; }

    /// <summary>
    /// <see cref="Sample"/> being tested and approved.
    /// </summary>
    public Sample Sample { get; set; }

    /// <summary>
    /// Examination results being validated (<see cref="ResultData"/>).
    /// </summary>
    public ResultData Data { get; set; }

}
