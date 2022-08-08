using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
{

    /// <summary>
    /// Represents laboratory's location, such as sample collection point, satellite or central lab
    /// </summary>
    public class Location
    {

        /// <summary>
        /// Identifier in the LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Code of the location
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name of the location
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

    }

}
