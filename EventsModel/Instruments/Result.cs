using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Occurs when results is received from a instrument (topic://instruments/results)
    /// </summary>
    public class Result : BaseMessage
    {

        public override string DefaultAddress => "topic://instruments/results";

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
