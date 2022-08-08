using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Payments
{

    /// <summary>
    /// Event. Occurs when a payment is made 
    /// Default address: topic://instruments/queries
    /// </summary>
    public class Payment : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://payments";

        /// <summary>
        /// Id of the payment in LIS iLab
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Type of payment (<see cref="PaymentType"/>
        /// </summary>
        public PaymentType PaymentType { get; set; } 

        /// <summary>
        /// The amount. Negative values represent refunds
        /// </summary>
        public decimal Amount { get; set; }  
        
        /// <summary>
        /// <see cref="Receipt"/> from fiscal device, if such is printed
        /// </summary>
        public Receipt Receipt { get; set; }


    }

}
