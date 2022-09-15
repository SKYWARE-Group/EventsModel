using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Payments
{

    /// <summary>
    /// Represent payment terminal transaction, associated with a given <see cref="Payment"/>
    /// </summary>
    public class CardTransaction
    {

        /// <summary>
        /// Id of the terminal
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// Number of the transaction (sequence number for given terminal, reset daily)
        /// </summary>
        public string TransactionNumber { get; set; }

        /// <summary>
        /// Card scheme, such as 'VISA CREDIT'
        /// </summary>
        public string CardScheme { get; set; }

    }

}
