using System;
using System.Collections.Generic;
using System.Text;
using Skyware.Lis.EventsModel.Common;

namespace Skyware.Lis.EventsModel.SampleTracking
{

    /// <summary>
    /// Event. Occurs when set of samples is transfered from one to another <see cref="Location"/>
    /// Deafualt address: topic://smp-tracking/shipment
    /// </summary>
    public class SampleShipment : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://smp-tracking/shipment";

        /// <summary>
        /// True if shipment is sent, false if it is received
        /// </summary>
        public bool IsSent { get; set; }

        /// <summary>
        /// Identifier in the LIS iLab
        /// </summary>
        public int ShipmentId { get; set; }

        /// <summary>
        /// Sendning <see cref="Location"/>
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

}
