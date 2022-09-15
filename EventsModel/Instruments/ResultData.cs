using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Represents examination result data
    /// </summary>
    public class ResultData
    {

        /// <summary>
        /// Resolved <see cref="Test"/>
        /// </summary>
        public Test Test { get; set; }

        /// <summary>
        /// Textual result representaion
        /// </summary>
        public string Reult { get; set; }

        /// <summary>
        /// Decimal value of the results, in case it is numeric value
        /// </summary>
        public decimal? DecimalResult { get; set; }

        /// <summary>
        /// Result flags
        /// </summary>
        public IEnumerable<Flag> InstrumentFlags { get; set; }

        /// <summary>
        /// Value based (iLab) flag according to reference ranges (see iLab docs)
        /// </summary>
        public byte? Flag { get; set; }

    }

}
