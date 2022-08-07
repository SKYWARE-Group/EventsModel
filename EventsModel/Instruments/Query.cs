using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Event. Occurs when instrument queries test selection by SampleId (barcode) 
    /// Default address: topic://instruments/queries
    /// </summary>
    [Event("topic://instruments/queries")]
    public class Query : BaseMessage
    {

        public override string DefaultAddress => "topic://instruments/queries";

        /// <summary>
        /// Instrument which made the query
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// Sample, subject of the query
        /// </summary>
        public Sample Sample { get; set; }

       
    }

}
