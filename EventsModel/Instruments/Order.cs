namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Event. Occurs when LIS sends a sample order to an instrument
    /// Default address: topic://instruments/orders
    /// </summary>
    [Event("topic://instruments/orders")]
    public class Order : BaseMessage
    {

        public override string DefaultAddress => "topic://instruments/orders";

        /// <summary>
        /// Instrument to which the order is sent
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// Ordered sample
        /// </summary>
        public Sample Sample { get; set; }


        /// <summary>
        /// Ordered items (Test slection)
        /// </summary>
        public Test[] Tests { get; set; }

    }

}
