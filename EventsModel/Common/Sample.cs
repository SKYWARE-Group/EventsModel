using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
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
        /// LOINC of the sample (sample type)
        /// </summary>
        public string LoincCode { get; set; }

        /// <summary>
        /// Laboratory wide code for sample type, printed on the tube
        /// </summary>
        public string LaboratoryCode { get; set; }

        /// <summary>
        /// The date and time the sample has been taken
        /// </summary>
        public DateTime? Taken { get; set; }

        /// <summary>
        /// Barcode of the original <see cref="Sample"/>, in case of aliquote
        /// </summary>
        public string DerivedFrom { get; set; }

    }

}
