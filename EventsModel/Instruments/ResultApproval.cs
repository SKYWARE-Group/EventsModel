using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Event. Occurs when test result is approved and sent to LIS
    /// Default address: topic://instruments/result-approvals
    /// </summary>
    [Event("topic://instruments/result-approvals")]
    public class ResultApproval : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://instruments/result-approvals";

        /// <summary>
        /// <see cref="Instrument"/> from which the results are received
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// <see cref="Sample"/> being tested and approved
        /// </summary>
        public Sample Sample { get; set; }

        /// <summary>
        /// Examination results being validated (<see cref="ResultData"/>)
        /// </summary>
        public ResultData Data { get; set; }

    }

}
