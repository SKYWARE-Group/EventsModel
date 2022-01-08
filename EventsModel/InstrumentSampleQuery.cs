using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel
{

    /// <summary>
    /// Instrument makes query for a test selection by SampleId (barcode)
    /// </summary>
    public class InstrumentSampleQuery : BaseMessage
    {

        /// <summary>
        /// Id of the instrument which makes query as it is defined in target LIS
        /// </summary>
        public string InstrumentId { get; set; }

        /// <summary>
        /// Name of the instrument which makes query as it is defined in target LIS
        /// </summary>
        public string InstrumentName { get; set; }

        /// <summary>
        /// SampleId (barcode) of a tube or vessel
        /// </summary>
        public string SampleId { get; set; }

        /// <summary>
        /// Disk or rack identifier where sample is found
        /// </summary>
        public string DiskOrRackId { get; set; }

        /// <summary>
        /// Position in the disk/rack of the sample
        /// </summary>
        public string DiskOrRackPosition { get; set; }

        /// <summary>
        /// Sequence number or any other identifier by which sample is known in the quering instrument
        /// </summary>
        public string InstrumentSampleId { get; set; }


    }

}
