using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Event. Occurs when  <see cref="Instrument"/> queries test selection by Sample Id (barcode) 
    /// Default address: topic://instruments/queries
    /// </summary>
    public class Query : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://instruments/queries";

        /// <summary>
        /// <see cref="Instrument"/> which made the query
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// <see cref="Sample"/>, subject of the query
        /// </summary>
        public Sample Sample { get; set; }

       
    }

}
