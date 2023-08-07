// Ignore Spelling: smp

using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.SampleTracking;


/// <summary>
/// Event. Occurs when set of samples is transfered from one to another <see cref="Location"/>
/// Default address: topic://smp-tracking/shipments
/// </summary>
public class SampleShipment : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://smp-tracking/shipments";

    /// <summary>
    /// True if shipment is sent, false if it is received
    /// </summary>
    public bool IsSent { get; set; }

    /// <summary>
    /// Identifier in the LIS iLab
    /// </summary>
    public int ShipmentId { get; set; }

    /// <summary>
    /// Sending <see cref="Location"/>
    /// </summary>
    public Location Sender { get; set; }

    /// <summary>
    /// Date and time the shipment is sent
    /// </summary>
    public DateTime Sent { get; set; }

    /// <summary>
    /// Intended delivery <see cref="Location"/>
    /// </summary>
    public Location Receiver { get; set; }

    /// <summary>
    /// Date and time the shipment is received
    /// </summary>
    public DateTime? Received { get; set; }

    /// <summary>
    /// Shipment's content (collection of <see cref="Sample"/>)
    /// </summary>
    public IEnumerable<Sample> Samples { get; set; }

}
