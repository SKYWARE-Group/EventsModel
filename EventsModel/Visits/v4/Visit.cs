using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Visits.v4
{

    /// <summary>
    /// Represent a simple visit of the <see cref="Patient"/> in the laboratory
    /// </summary>
    public class Visit
    {

        /// <summary>
        /// Identifier in LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="Patient"/> of the visit
        /// </summary>
        public Patient Patient { get; set; }

        /// <summary>
        /// Collection of <see cref="Examination"/> ordered in this vist
        /// </summary>
        public IEnumerable<Examination> Examinations { get; set; }

        /// <summary>
        /// Collection of <see cref="Sample"/>, associated with this vist
        /// </summary>
        public IEnumerable<Sample> Samples { get; set; }

    }

}
