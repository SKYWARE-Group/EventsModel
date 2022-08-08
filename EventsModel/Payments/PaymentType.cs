using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Payments
{

    /// <summary>
    /// Represents payment type, such as "Cash", ""Voucher", etc.
    /// </summary>
    public class PaymentType
    {

        /// <summary>
        /// Identifier of the type according to LIS iLab
        /// </summary>
        public int Id { get; set; }  

        /// <summary>
        /// Descriptive name
        /// </summary>
        public string Name { get; set; }

    }

}
