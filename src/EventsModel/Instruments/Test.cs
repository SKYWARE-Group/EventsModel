using Skyware.Lis.EventsModel.Common;
using System;

namespace Skyware.Lis.EventsModel.Instruments;


/// <summary>
/// Test in orders and results (Instruments communication)
/// </summary>
public class Test : TestBase
{

    /// <summary>
    /// Test code as it is known in the instrument
    /// </summary>
    public string InstrumentCode { get; set; }

    /// <summary>
    /// Represents discriminator of the test code
    /// </summary>
    public string CodeModifier { get; set; }

    /// <summary>
    /// Test name as it is known in target LIS
    /// </summary>
    /// <remarks>
    /// This is an alias of <see cref="TestBase.Name"/> property for
    /// backward compatibility.
    /// </remarks>
    [Obsolete("Use Name property.")]
    public string TestName => Name;

}
