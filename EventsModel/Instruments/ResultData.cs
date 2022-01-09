using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Represents test result data
    /// </summary>
    public class ResultData
    {

        /// <summary>
        /// Resolved test
        /// </summary>
        public Test Test { get; set; }

        /// <summary>
        /// Textual result
        /// </summary>
        public string Reult { get; set; }

        /// <summary>
        /// Deciamal value of the results, in case it is numeric value
        /// </summary>
        public decimal? DecResult { get; set; }

        /// <summary>
        /// Comma separated flags, comming from the instrument
        /// </summary>
        public string InstrumentFlags { get; set; }

        /// <summary>
        /// Valud based (iLab) flag according to reference ranges (see iLab docs)
        /// </summary>
        public int? Flag { get; set; }


    }

}
