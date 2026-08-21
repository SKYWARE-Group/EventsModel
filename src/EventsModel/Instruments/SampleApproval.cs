using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.Instruments;

/// <summary>
/// Occurs when multiple test results are approved and sent to LIS.
/// </summary>
/// <remarks>
/// This event is usually emitted from the Broker processor, which handles
/// <see cref="ResultApproval"/> and combines many single approvals into 
/// composite one (with some time delay) to avoid many database (or other) 
/// interactions in case of massive approval.
/// </remarks>
public class SampleApproval : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://instruments/sample-approvals";

    /// <summary>
    /// <see cref="Sample"/> being tested and approved.
    /// </summary>
    /// <remarks>
    /// Note that in this context this is a common sample, not the one specific to the instrument,
    /// therefore instrument specific data, such as Rack number, Rack position etc.
    /// may not be available event different instruments provide such information, if
    /// approved results for given sample are received from different instruments.
    /// </remarks>
    public Sample Sample { get; set; }

    /// <summary>
    /// Results of the sample grouped by an instrument.
    /// </summary>
    public IEnumerable<InstrumentResults> Results { get; set; }

}
