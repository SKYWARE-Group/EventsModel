using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Occurs when test result is approved and sent to LIS
    /// </summary>
    public class ResultApproval : BaseMessage
    {

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
