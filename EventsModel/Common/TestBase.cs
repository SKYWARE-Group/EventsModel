namespace Skyware.Lis.EventsModel.Common;

/// <summary>
/// Test (assay, analyte)
/// </summary>
public abstract class TestBase
{

    /// <summary>
    /// Test Id as it is known in target LIS
    /// </summary>
    public string TestId { get; set; }

    /// <summary>
    /// Test name as it is known in target LIS
    /// </summary>
    public string Name { get; set; }

}
