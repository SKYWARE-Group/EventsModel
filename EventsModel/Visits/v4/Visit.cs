using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Visits.v4
{

    public class Visit
    {

        public int Id { get; set; }

        public Patient Patient { get; set; }

        public IEnumerable<Examination> Examinations { get; set; }

        public IEnumerable<Sample> Samples { get; set; }

    }

}
