using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Payments
{

    /// <summary>
    /// Represent payment terminal transaction
    /// </summary>
    public class CardTransaction
    {

        /// <summary>
        /// If in LIS iLab
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the terminal
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// Number of the transaction
        /// </summary>
        public string TransactionNumber { get; set; }

    }

}
