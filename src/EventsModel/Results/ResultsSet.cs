using Skyware.Lis.EventsModel.Common;
using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.Results;

/// <summary>
/// Represent set of saved results.
/// </summary>
public class ResultsSet : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://results";

    /// <summary>
    /// PK of the Visit in LIS iLab.
    /// </summary>
    public int? VisitId { get; set; }

    /// <summary>
    /// Id of a sale schema in LIS iLab.
    /// </summary>
    public int? SchemaId { get; set; }

    /// <summary>
    /// Find or clinic #1
    /// </summary>
    public int? Fund1Id { get; set; }

    /// <summary>
    /// Find or clinic #2
    /// </summary>
    public int? Fund2Id { get; set; }

    /// <summary>
    /// Id of the referring doctor in LIS iLab.
    /// </summary>
    public int? DoctorId { get; set; }

    /// <summary>
    /// Patient
    /// </summary>
    public Patient Patient { get; set; }

    /// <summary>
    /// Collection of changed results.
    /// </summary>
    IList<TestResult> Results { get; set; }

}
