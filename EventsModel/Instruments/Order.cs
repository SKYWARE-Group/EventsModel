namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Occurs when LIS sends a sample order to a instrument (topic://instruments/orders)
    /// </summary>
    public class Order : BaseMessage
    {

        public override string DefaultAddress => "topic://instruments/orders";

        /// <summary>
        /// Instrument
        /// </summary>
        public Instrument Instrument { get; set; }

        /// <summary>
        /// Sample
        /// </summary>
        public Sample Sample { get; set; }


        /// <summary>
        /// Ordered items (Test slection)
        /// </summary>
        public Test[] Tests { get; set; }

    }

}
