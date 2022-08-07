using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Visits
{

    /// <summary>
    /// Represent a sample to be tested
    /// </summary>
    public class Sample
    {

        /// <summary>
        /// Barcode of the sample (unique across LIS iLab)
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Code (usially LOINC) of the sample (sample type)
        /// </summary>
        public string TypeCode { get; set; }

        /// <summary>
        /// Date and time sample has been taken
        /// </summary>
        public DateTime? Taken { get; set; }

        /// <summary>
        /// Barcode of the original <see cref="Sample"/>, in case of aliquote
        /// </summary>
        public string DerivedFrom { get; set; }

    }

}
