namespace Skyware.Lis.EventsModel.Instruments;

/// <summary>
/// Occurs when test result is approved and sent to LIS
/// </summary>
public class ResultApproval : Result
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://instruments/result-approvals";

}
