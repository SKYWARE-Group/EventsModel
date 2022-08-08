using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
{

    /// <summary>
    /// Represents a set of samples, shich are transfered from one to another <see cref="Location"/>
    /// </summary>
    public class SampleShipment
    {

        /// <summary>
        /// Identifier in the LIS iLab
        /// </summary>
        public int Id { get; set; }

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
        /// Shipment's content
        /// </summary>
        public IEnumerable<Sample> Samples { get; set; }    

    }

}
