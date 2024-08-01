using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.Instruments;


/// <summary>
/// Represents examination result data
/// </summary>
public class ResultData
{

    /// <summary>
    /// Resolved <see cref="Test"/>
    /// </summary>
    public Test Test { get; set; }

    /// <summary>
    /// Result values.
    /// </summary>
    public ResultBag Result { get; set; } = new();

    /// <summary>
    /// Instrument's flags.
    /// </summary>
    public IEnumerable<InstrumentFlag> InstrumentFlags { get; set; }

    /// <summary>
    /// Flag, according to reference range (1-7, 10, 11).
    /// </summary>
    /// <remarks>
    /// 1=ultra low, 2=very low, 3=low, 5=high, 6=very high, 7=ultra high, 10=star.
    /// 4=no flag. Null means the flag is not calculated.
    /// </remarks>
    public byte? FlagLevel { get; set; } // No flag, see iLab

}
