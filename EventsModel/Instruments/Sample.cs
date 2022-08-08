using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments
{

    /// <summary>
    /// Represents sample in communication with the <see cref="Instrument"/>
    /// </summary>
    public class Sample
    {

        /// <summary>
        /// SampleId (barcode) of a tube or vessel
        /// </summary>
        public string SampleId { get; set; }

        /// <summary>
        /// Disk or rack identifier where sample is found in given instrument
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

        /// <summary>
        /// Code of the sample type a it is known to the instrument
        /// </summary>
        public string InstrumentCode { get; set; }

        /// <summary>
        /// Date of time when the sample is taken
        /// </summary>
        public DateTime? Taken { get; set; }


    }

}
