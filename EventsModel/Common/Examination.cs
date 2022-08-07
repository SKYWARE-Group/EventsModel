using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
{

    /// <summary>
    /// Represent laboratory examination
    /// </summary>
    public class Examination
    {

        /// <summary>
        /// Identifier in LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Code (usually LOINC) of the examination
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name of the examination
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// True if the examination is a panel (profile)
        /// </summary>
        public bool IsPanel { get; set; }

    }

}
