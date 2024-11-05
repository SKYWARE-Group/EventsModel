using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel.Instruments;

/// <summary>
/// Set of one or more test results for a sample, received from particular instrument
/// </summary>
public class InstrumentResults
{

    /// <summary>
    /// <see cref="Instrument"/> from which the results are received
    /// </summary>
    public Instrument Instrument { get; set; }

    /// <summary>
    /// Approved results from the instrument
    /// </summary>
    public IEnumerable<ResultData> Results { get; set; }

}
