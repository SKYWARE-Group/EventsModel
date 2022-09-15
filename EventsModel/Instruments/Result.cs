using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Event. Occurs when results is received from an <see cref="Instrument"/> 
    /// Default address: topic://instruments/results
    /// </summary>
    public class Result : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://instruments/results";

        /// <summary>
        /// <see cref="Instrument"/> from which the result is received
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// <see cref="Sample"/> being tested
        /// </summary>
        public Sample Sample { get; set; }

        /// <summary>
        /// Examination results (<see cref="ResultData"/>)
        /// </summary>
        public ResultData Data { get; set; }

    }

}
