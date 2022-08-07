using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Visits
{

    /// <summary>
    /// Represent a patient (human, animal, etc.)
    /// </summary>
    public class Patient
    {

        /// <summary>
        /// Identifier in the LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of well-known identifier of the patient
        /// </summary>
        public string NationalIdentifierType { get; set; }

        /// <summary>
        /// Indentifier of the, such as SSN, EGN, etc.
        /// </summary>
        public string NationalIdentifer { get; set; }

        /// <summary>
        /// First (given) name
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Second name or initials
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last (family) name
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// False if date of birth is known, otherwise false (for calculation of age)
        /// </summary>
        public bool IsDobApproximate { get; set; }

        /// <summary>
        /// True if man, false if woman and null for unknwon/non binary
        /// </summary>
        public bool? IsMale { get; set; }

    }

}
