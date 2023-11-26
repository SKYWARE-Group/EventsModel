namespace Skyware.Lis.EventsModel.Instruments;


/// <summary>
/// Test in orders and results (Instruments communication)
/// </summary>
public class Test
{

    /// <summary>
    /// Test Id as it is known in target LIS
    /// </summary>
    public string TestId { get; set; }

    /// <summary>
    /// Test name as it is known in target LIS
    /// </summary>
    public string TestName { get; set; }

    /// <summary>
    /// Test code as it is known in the instrument
    /// </summary>
    public string InstrumentCode { get; set; }

    /// <summary>
    /// Represents discriminator of the test code
    /// </summary>
    public string CodeModifier { get; set; }

}
