using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Event. Occurs when <see cref="Referral"/> is imported or removed
    /// Deafualt address: topic://bg-nhis/ref-import
    /// </summary>
    public class ReferralImport : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://bg-nhis/ref-import";

        /// <summary>
        /// Operation indicator - true for import and false for removal
        /// </summary>
        public bool IsRemoval { get; set; } = false;

        /// <summary>
        /// Sale to which referral is imported or from which is removed
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Sale scehma of the Sale
        /// </summary>
        public int SchemaId { get; set; }

        /// <summary>
        /// Imported/Removed <see cref="Referral"/>
        /// </summary>
        public Referral Referral { get; set; }

    }

}
