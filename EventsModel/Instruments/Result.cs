using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Occurs when results is received from a instrument
    /// </summary>
    public class Result : BaseMessage
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
