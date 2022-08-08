using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Examination, order with Bulgarian NHIS <see cref="Referral"/>
    /// </summary>
    public class NhisExamination
    {

        /// <summary>
        /// Code of the examination, according to Bulgarian NHIF
        /// </summary>
        public string NhifCode { get; set; }

        /// <summary>
        /// Code of the examination, according to Bulgarian NHIS (CL022)
        /// </summary>
        public string NhisCode { get; set; }

        /// <summary>
        /// Name of the examination
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// LIS iLab <see cref="Examination"/>
        /// </summary>
        public Examination Examination { get; set; }


    }

}
