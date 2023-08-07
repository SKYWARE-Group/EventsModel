// Ignore Spelling: smp

using Skyware.Lis.EventsModel.Common;

namespace Skyware.Lis.EventsModel.SampleTracking;


/// <summary>
/// Event. Occurs when <see cref="Common.Sample"/> is is checked in or out of given <see cref="Common.Location"/>
/// Default address: topic://smp-tracking/check-in
/// </summary>
public class CheckIn : BaseMessage
{

    /// <summary>
    /// Default address where messages are produced
    /// </summary>
    public override string DefaultAddress => "topic://smp-tracking/check-in";

    /// <summary>
    /// True if operation is check in, false - check out
    /// </summary>
    public bool IsCheckIn { get; set; }

    /// <summary>
    /// Subject of the operation
    /// </summary>
    public Sample Sample { get; set; }

    /// <summary>
    /// <see cref="Location"/> where operation is made
    /// </summary>
    public Location TargetLocation { get; set; }

}
