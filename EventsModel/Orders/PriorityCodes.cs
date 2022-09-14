using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Orders
{

    /// <summary>
    /// HL7 compatable priority codes (0485 - Extended Priority Codes)
    /// </summary>
    public class PriorityCodes
    {

        /// <summary>
        /// As soon as posible
        /// </summary>
        public const string ASAP = "A";

        /// <summary>
        /// Callback
        /// </summary>
        public const string CALLBACK = "C";

        /// <summary>
        /// Prior to operation
        /// </summary>
        public const string PREOP = "P";

        /// <summary>
        /// As needed
        /// </summary>
        public const string AS_NEEDED = "PRN";

        /// <summary>
        /// Routine (default priority)
        /// </summary>
        public const string ROUTINE = "R";

        /// <summary>
        /// STAT, emergency
        /// </summary>
        public const string STAT = "S";

        /// <summary>
        /// Time critical
        /// </summary>
        public const string TIMING_CRITICAL = "T";


    }
}
