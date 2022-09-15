using Skyware.Lis.EventsModel.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Event. Occurs when action with a <see cref="Referral"/> is made
    /// Deafualt address: topic://topic://bg-nhis/referrals
    /// </summary>
    public class ReferralAction : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://bg-nhis/referrals";

        /// <summary>
        /// Action made with the referral, according to <see cref="ReferralEvents"/>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Sale to which referral is imported
        /// </summary>
        public int? SaleId { get; set; }

        /// <summary>
        /// Sale scehma of the Sale to which referral is imported
        /// </summary>
        public int? SchemaId { get; set; }

        /// <summary>
        /// Imported/Removed <see cref="Referral"/>
        /// </summary>
        public Referral Referral { get; set; }

    }

}
