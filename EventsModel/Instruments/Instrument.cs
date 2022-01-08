using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Represents instrument object in LIS communication
    /// </summary>
    public class Instrument
    {

        /// <summary>
        /// Id of the instrument which makes query as it is defined in target LIS
        /// </summary>
        public string InstrumentId { get; set; }

        /// <summary>
        /// Name of the instrument which makes query as it is defined in target LIS
        /// </summary>
        public string InstrumentName { get; set; }

    }

}
