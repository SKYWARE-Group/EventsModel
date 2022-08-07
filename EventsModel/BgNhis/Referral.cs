using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Represent e-referral from Bulgarian NHIS (form #4 of MoH)
    /// </summary>
    public class Referral
    {

        /// <summary>
        /// Unique identifier of the referral in Bulgarian NHIS
        /// </summary>
        public string Nrn { get; set; }

        /// <summary>
        /// Issuer's identifier
        /// </summary>
        public string Lrn { get; set; }

        /// <summary>
        /// The Rila channel, the referral is read, locked or unlocked (null if Arda is used)
        /// </summary>
        public int? RilaId { get; set; }

        /// <summary>
        /// Date of issuance
        /// </summary>
        public DateTime Issued { get; set; }    

        /// <summary>
        /// <see cref="Patient"/> to which referral is issued
        /// </summary>
        public Patient Patient { get; set; }

        /// <summary>
        /// Practitioner (<see cref="BgDoctor"/>), who issued the referral
        /// </summary>
        public BgDoctor Issuer { get; set; }

        /// <summary>
        /// Responsable dcotor (<see cref="BgDoctor"/>, the one who performes examinations)
        /// </summary>
        public BgDoctor LaboratoryDoctor { get; set; }


        /// <summary>
        /// Collection of <see cref="NhisExamination"/>, ordered with this referral
        /// </summary>
        public IEnumerable<NhisExamination> Items { get; set; }

    }

}
