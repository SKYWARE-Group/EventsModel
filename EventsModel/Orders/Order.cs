using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.Orders;


/// <summary>
/// Represents Order in LIS iLab (Orders database)
/// </summary>
public class Order
{

    /// <summary>
    /// Id of the order in LIS iLab (Orders database)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Priority code (see <see cref="PriorityCodes"/>), compatible with HL7 table 0485 (Extended Priority Codes)
    /// </summary>
    public string PriorityCode { get; set; } = PriorityCodes.ROUTINE;

    /// <summary>
    /// If values is set (known), shows if order is addition to previously sent one 
    /// </summary>
    public bool? IsAddition { get; set; }

    /// <summary>
    /// Not null value indicates desired date and time of sample collection and execution
    /// </summary>
    public DateTime? ScheduledTime { get; set; } = null;

    /// <summary>
    /// <see cref="Patient"/> to which order is made
    /// </summary>
    public Patient Patient { get; set; }

    /// <summary>
    /// <see cref="Organization"/> which made the order
    /// </summary>
    public Organization Origin { get; set; }

    /// <summary>
    /// Collection of <see cref="Diagnosis"/>, associated with the order
    /// </summary>
    public IEnumerable<Diagnosis> Diagnoses { get; set; }

    /// <summary>
    /// Collection of <see cref="Sample"/>, associated with the order
    /// </summary>
    public IEnumerable<Sample> Samples { get; set; }

    /// <summary>
    /// Collection of <see cref="Examination"/>, associated with the order
    /// </summary>
    public IEnumerable<Examination> Examinations { get; set; }

}
