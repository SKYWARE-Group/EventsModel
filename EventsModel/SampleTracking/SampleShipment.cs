// Ignore Spelling: smp

using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.SampleTracking;


/// <summary>
/// Occurs when set of samples is transfered from one to another <see cref="Location"/>
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

    /// <summary>
    /// Identifier of the courier responsible for the shipment
    /// 
    public int? CourierId { get; set; }

    /// <summary>
    /// Identifier of the carrier responsible for the shipment
    /// </summary>
    public int? CarrierId { get; set; }

    /// <summary>
    /// Employee of the carrier responsible for the shipment
    /// </summary>
    public string CarrierEmployee { get; set; }

    /// <summary>
    /// Reference to the document that initiated the shipment.
    /// </summary>
    public string DocumentRef { get; set; }

    /// <summary>
    /// Indicates whether the shipment is a draft
    /// </summary>
    public bool IsDraft { get; set; } = true;

    /// <summary>
    /// Indicates whether the shipment is completed
    /// </summary>
    public bool IsCompleted { get; set; } = false;

}
