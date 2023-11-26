using Skyware.Lis.EventsModel.Common;
using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.Visits;

/// <summary>
/// Represents base Visit object (v4.x)
/// </summary>
public class Sale : BaseMessage
{


    /// <inheritdoc/>
    public override string DefaultAddress => "topic://sales";

    /// <summary>
    /// Identifier in LIS iLab
    /// </summary>
    public int SaleId { get; set; }

    /// <summary>
    /// Type of the event
    /// </summary>
    public string EventType { get; set; } = CommonEvents.CREATED;

    /// <summary>
    /// Sale schema of the sale
    /// </summary>
    public SaleSchema SaleSchema { get; set; }

    /// <summary>
    /// <see cref="Patient"/> of the visit
    /// </summary>
    public Patient Patient { get; set; }

    /// <summary>
    /// Referring doctor
    /// </summary>
    public Doctor Doctor { get; set; }

    /// <summary>
    /// Collection of <see cref="Examination"/> ordered in this visit
    /// </summary>
    public IEnumerable<Examination> Examinations { get; set; }

    /// <summary>
    /// Collection of <see cref="Sample"/>, associated with this visit
    /// </summary>
    public IEnumerable<Sample> Samples { get; set; }

}
