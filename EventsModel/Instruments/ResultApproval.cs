using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Occurs when test result is approved and sent to LIS (topic://instruments/result-approvals)
    /// </summary>
    public class ResultApproval : BaseMessage
    {

        public override string DefaultAddress => "topic://instruments/result-approvals";

        /// <summary>
        /// Instrument
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// Sample
        /// </summary>
        public Sample Sample { get; set; }

        /// <summary>
        /// Test data
        /// </summary>
        public ResultData Data { get; set; }

    }

}
