using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Event. Occurs when <see cref="Referral"/> is searched
    /// Deafualt address: topic://bg-nhis/ref-search
    /// </summary>
    public class ReferralSearch : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://bg-nhis/ref-search";

        /// <summary>
        /// True, if search is by PID, false if it is by NRN
        /// </summary>
        public bool ByPid { get; set; } = false;

        /// <summary>
        /// Start date (applicable in search by PID)
        /// </summary>
        public DateTime? DateStart { get; set; }

        /// <summary>
        /// End date (applicable in search by PID)
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Nrn or Pid the search is made with
        /// </summary>
        public string SearchString { get; set; }

        /// <summary>
        /// If operation was successful
        /// </summary>
        public bool IsSucceeded { get; set; } = false;

        /// <summary>
        /// Description of the error, in case of operation failure
        /// </summary>
        public string FailureReason { get; set; }

        /// <summary>
        /// Search results, collection of <see cref="Referral"/>
        /// </summary>
        public IEnumerable<Referral> Referrals { get; set; }

    }

}
