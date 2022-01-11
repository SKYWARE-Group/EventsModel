using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Occurs when instrument queries test selection by SampleId (barcode) (topic://instruments/queries)
    /// </summary>
    public class Query : BaseMessage
    {

        public override string DefaultAddress => "topic://instruments/queries";

        /// <summary>
        /// Instrument
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// Sample
        /// </summary>
        public Sample Sample { get; set; }

       
    }

}
