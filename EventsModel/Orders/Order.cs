using Skyware.Lis.EventsModel.BgNhis;
using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Orders
{

    /// <summary>
    /// Represents Order in LIS iLab (Orders database)
    /// </summary>
    public class Order
    {

        /// <summary>
        /// Id of the order in LIS iLab (Orders database)
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// <see cref="Patient"/> to which order is made
        /// </summary>
        public Patient Patient { get; set; }

        /// <summary>
        /// <see cref="Organization"/> which made the order
        /// </summary>
        public Organization Origin { get; set; }

        /// <summary>
        /// Priority code (see <see cref="PriorityCodes"/>), compatable with HL7 table 0485 (Extended Priority Codes)
        /// </summary>
        public string PriorityCode { get; set; } = PriorityCodes.ROUTINE;

        /// <summary>
        /// Not null value indicates desired date and time of sample collection and execution
        /// </summary>
        public DateTime? ScheduledTime { get; set; } = null;

        /// <summary>
        /// Collection of <see cref="Sample"/>, associated with the order
        /// </summary>
        public IEnumerable<Sample> Samples { get; set; }

        /// <summary>
        /// Collection of <see cref="Examination"/>, associated with the order
        /// </summary>
        public IEnumerable<Examination> Examinations { get; set; }

    }

}
