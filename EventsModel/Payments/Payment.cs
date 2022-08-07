using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Payments
{

    /// <summary>
    /// Event. Occurs when a payment is made 
    /// Default address: topic://instruments/queries
    /// </summary>
    [Event("topic://payments")]
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
        /// The amount. Negative values represents refunds
        /// </summary>
        public decimal Amount { get; set; }    


    }

}
