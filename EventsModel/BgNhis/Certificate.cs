using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.BgNhis
{

    /// <summary>
    /// Represents e-signature (X509 certificate on chip and supplemental data)
    /// </summary>
    public class Certificate
    {

        /// <summary>
        /// Serial number of the certificate
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Frendly name of the Rila record
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Doctor's UIN (according to Bulgarian BMA)
        /// </summary>
        public string Uin { get; set; }

        /// <summary>
        /// Practice number associated with this record
        /// </summary>
        public string PracticeNumber { get; set; }

    }

}
