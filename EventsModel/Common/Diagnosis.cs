using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
{

    /// <summary>
    /// ICD-10 ednoced diagnosis
    /// </summary>
    public class Diagnosis
    {

        /// <summary>
        /// Code of siagnosis, dagger one in case of pair ecnoded diagnosis
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Supplemental code in case of diagnosis pair, AKA asterisk code
        /// </summary>
        public string SecondaryCode { get; set; }

    }

}
