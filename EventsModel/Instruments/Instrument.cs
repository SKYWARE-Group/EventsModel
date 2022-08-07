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
        /// Id of the instrument as it is defined in target LIS
        /// </summary>
        public int InstrumentId { get; set; }

        /// <summary>
        /// Name of the instrument as it is defined in target LIS
        /// </summary>
        public string InstrumentName { get; set; }

    }

}
