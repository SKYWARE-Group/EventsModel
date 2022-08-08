using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Event. Occurs when <see cref="Referral"/> is locked or unloked
    /// Deafualt address: topic://bg-nhis/ref-lock
    /// </summary>
    public class ReferralLock : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://bg-nhis/ref-lock";

        /// <summary>
        /// True, if operation is lock, false if it is unlock (release)
        /// </summary>
        public bool IsLock { get; set; } = true;

        /// <summary>
        /// If operation was successful
        /// </summary>
        public bool IsSucceeded { get; set; } = true;

        /// <summary>
        /// Description of the error, in case of operation failure
        /// </summary>
        public string FailureReason { get; set; }

        /// <summary>
        /// <see cref="Referral"/> on which operation is made
        /// </summary>
        public Referral Referral { get; set; }

    }

}
