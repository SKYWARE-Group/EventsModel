using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel
{

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class EventAttribute : System.Attribute
    {
        public string DeafultAddress;

        public EventAttribute(string deafultAddress)
        {
            this.DeafultAddress = deafultAddress;
        }
    }

}
