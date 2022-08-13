using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.SampleTracking
{

    /// <summary>
    /// Event. Occurs when <see cref="Common.Sample"/> is is checkd in or out of given <see cref="Common.Location"/>
    /// Deafualt address: topic://smp-tracking/check-in
    /// </summary>
    public class CheckIn : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://smp-tracking/check-in";

        /// <summary>
        /// True if operation is chek in, false - check out
        /// </summary>
        public bool IsChekIn { get; set; }

        /// <summary>
        /// Subject of the operation
        /// </summary>
        public Sample Sample { get; set; }

        /// <summary>
        /// <see cref="Location"/> where operation is made
        /// </summary>
        public Location TargetLocation { get; set; }

    }

}
