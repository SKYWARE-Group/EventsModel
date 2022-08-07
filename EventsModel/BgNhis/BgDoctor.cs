using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Doctor, according to Bulgarian regulations
    /// </summary>
    public class BgDoctor : Doctor
    {

        /// <summary>
        /// Speciality code, according to NHIF
        /// </summary>
        public string NhifSpecialityCoe { get; set; }

        /// <summary>
        /// Speciality code, according to NHIS (CL006)
        /// </summary>
        public string NhisSpecialityCode { get; set; }


    }

}
