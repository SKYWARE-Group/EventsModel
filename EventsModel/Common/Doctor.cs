using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
{

    /// <summary>
    /// Represent medical doctor
    /// </summary>
    public class Doctor : Person
    {

        /// <summary>
        /// Identifier in the LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Professional identifier issued by national or local authorities
        /// </summary>
        public string Identifier { get; set; }


    }


}
