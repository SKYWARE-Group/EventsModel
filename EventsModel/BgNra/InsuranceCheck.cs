using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNra
{

    /// <summary>
    /// Occurs when Health Insurance (Bulgaria, Nra) is checked (topic://bg-nra/insurance)
    /// </summary>
    public class InsuranceCheck : BaseMessage
    {

        public override string DefaultAddress => "topic://bg-nra/insurance";

        /// <summary>
        /// Visit to which the patient is associated in thi check
        /// </summary>
        public int VisitId { get; set; }

        /// <summary>
        /// Patient identifier type, according to iLab
        /// </summary>
        public int PidType { get; set; }

        /// <summary>
        /// Patient identifier
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// Zero means insured, any non zero values indicates problem with insurance
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Textual representation of a status
        /// </summary>
        public string StatusText { get; set; }

        /// <summary>
        /// Base64 encoded answer from NRZ
        /// </summary>
        public string OriginalFile { get; set; }


    }

}
