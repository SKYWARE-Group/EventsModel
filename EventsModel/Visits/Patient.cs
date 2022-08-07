using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Visits
{

    public class Patient
    {

        public int Id { get; set; }

        public string NationalIdentifierType { get; set; }

        public string NationalIdentifer { get; set; }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsDobApproximate { get; set; }

        public bool? IsMale { get; set; }

    }

}
