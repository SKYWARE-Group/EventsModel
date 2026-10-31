using System.Text.Json.Serialization;

namespace Skyware.Lis.EventsModel.Common;

/// <summary>
/// Test (assay, analyte), e.g. Glucose, Cholesterol, Hemoglobin A1c, etc.
/// </summary>
/// <remarks>
/// This is a base class for test representation in different contexts (Instruments, Results, etc.).
/// </remarks>
[JsonDerivedType(typeof(Instruments.Test))]
[JsonDerivedType(typeof(Results.Test))]
public abstract class TestBase
{

    /// <summary>
    /// Test Id as it is known in the LIS.
    /// </summary>
    public string TestId { get; set; }

    /// <summary>
    /// Test name as it is known in the LIS.
    /// </summary>
    public string Name { get; set; }

}
