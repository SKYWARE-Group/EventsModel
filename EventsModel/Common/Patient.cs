using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Common
{

    /// <summary>
    /// Represent a patient (human, animal, etc., inherits <see cref="Person"/>)
    /// </summary>
    public class Patient : Person
    {

        /// <summary>
        /// Identifier in the LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type Id in LIS iLab
        /// </summary>
        public int IdentifierTypeId { get; set; }

        /// <summary>
        /// Type of well-known identifier of the patient
        /// </summary>
        public string IdentifierTypeName { get; set; }

        /// <summary>
        /// Identifier of the, such as SSN, EGN, etc.
        /// </summary>
        public string Identifer { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// False if date of birth is known, otherwise true (for calculation of age)
        /// </summary>
        public bool IsDobApproximate { get; set; }

        /// <summary>
        /// Three-state gender indicator: true if man, false if woman and null for unknown/non binary
        /// </summary>
        public bool? IsMale { get; set; }

    }

}
