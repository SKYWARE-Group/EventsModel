using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Event. Occurs when results is received from an instrument 
    /// Default address: topic://instruments/results
    /// </summary>
    [Event("topic://instruments/results")]
    public class Result : BaseMessage
    {

        public override string DefaultAddress => "topic://instruments/results";

        /// <summary>
        /// Instrument from which the result is received
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// Sample being tested
        /// </summary>
        public Sample Sample { get; set; }

        /// <summary>
        /// Examination results
        /// </summary>
        public ResultData Data { get; set; }


    }

}
