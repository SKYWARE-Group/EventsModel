namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Occurs when LIS sends a sample order to a instrument
    /// </summary>
    public class Order : BaseMessage
    {

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
