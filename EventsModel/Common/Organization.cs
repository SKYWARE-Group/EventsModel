using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
{

    /// <summary>
    /// Represents partner organization - Insurance fund, Clinic or medicalpractice
    /// </summary>
    public class Organization
    {

        /// <summary>
        /// Identifier in the LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of organization
        /// </summary>
        public string Name { get; set; }

    }

}
