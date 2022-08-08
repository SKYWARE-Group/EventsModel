using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Event. Represent attempt for session creation
    /// Default address: topic://bg-rila/session
    /// </summary>
    public class Session : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://bg-nhis/session";

        /// <summary>
        /// If session was successfully created
        /// </summary>
        public bool IsSucceeded { get; set; }

        /// <summary>
        /// Certificate with which the session was established
        /// </summary>
        public Certificate Certificate { get; set; }

        /// <summary>
        /// Description of the error, in case of creation failure
        /// </summary>
        public string FailureReason { get; set; }

    }

}
