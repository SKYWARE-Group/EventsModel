using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Represents medical practice, registered by Bulgarian regulations
    /// </summary>
    public class MedicalPractice : Organization
    {

        /// <summary>
        /// Also known as RZOK code
        /// </summary>
        public string RegistryNumber { get; set; }

        /// <summary>
        /// Additional (RHIF) registration number
        /// </summary>
        public string NhifNumaber { get; set; }

    }

}
