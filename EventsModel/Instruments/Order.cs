namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Event. Occurs when LIS sends a sample order to an <see cref="Instrument"/>
    /// Default address: topic://instruments/orders
    /// </summary>
    [Event("topic://instruments/orders")]
    public class Order : BaseMessage
    {

        /// <summary>
        /// Default address where messages are produced
        /// </summary>
        public override string DefaultAddress => "topic://instruments/orders";

        /// <summary>
        /// <see cref="Instrument"/> to which the order is sent
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// Ordered <see cref="Sample"/>
        /// </summary>
        public Sample Sample { get; set; }


        /// <summary>
        /// Ordered items (Array of <see cref="Test"/>)
        /// </summary>
        public Test[] Tests { get; set; }

    }

}
