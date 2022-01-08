using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Test in orderr and results (Instruments communication)
    /// </summary>
    public class Test
    {

        /// <summary>
        /// Test Id as it is knwon in LIS
        /// </summary>
        public string TestId { get; set; }

        /// <summary>
        /// Test name as it is known in LIS
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// Test code as it is known in the target instrument
        /// </summary>
        public string InstrumentCode { get; set; }

    }

}
