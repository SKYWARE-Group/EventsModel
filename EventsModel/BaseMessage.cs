using Skyware.Lis.EventsModel.Common;
using System;
using System.Text.Json.Serialization;

// Ignore Spelling: ver

namespace Skyware.Lis.EventsModel;

/// <summary>
/// Base (abstract) class for all messages emitted by LIS iLab.
/// </summary>
[JsonDerivedType(typeof(SampleTracking.CheckIn))]
[JsonDerivedType(typeof(Instruments.Order))]
[JsonDerivedType(typeof(Instruments.Query))]
[JsonDerivedType(typeof(Instruments.Result))]
[JsonDerivedType(typeof(Instruments.ResultApproval))]
[JsonDerivedType(typeof(Instruments.SampleApproval))]
[JsonDerivedType(typeof(Orders.OrderAction))]
[JsonDerivedType(typeof(Results.ResultsSet))]
[JsonDerivedType(typeof(Visits.Sale))]
[JsonDerivedType(typeof(SampleTracking.CheckIn))]
[JsonDerivedType(typeof(SampleTracking.SampleShipment))]
[JsonDerivedType(typeof(Payments.Payment))]
[JsonDerivedType(typeof(BgNra.InsuranceCheck))]
[JsonDerivedType(typeof(BgNhis.ReferralAction))]
[JsonDerivedType(typeof(BgNhis.Session))]
public abstract class BaseMessage
{

    /// <summary>
    /// Default address where message should be send.
    /// </summary>
    [JsonIgnore]
    public abstract string DefaultAddress { get; }

    /// <summary>
    /// Id of the message, GUID
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Date and time (UTC) when message is generated.
    /// </summary>
    public DateTime EventTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Local date and time (according to receiver).
    /// </summary>
    public DateTime LocalEventTime => EventTime.ToLocalTime();

    /// <summary>
    /// Origin application name.
    /// </summary>
    public string OriginApp { get; set; }

    /// <summary>
    /// Origin application version.
    /// </summary>
    public string OriginAppVer { get; set; }

    /// <summary>
    /// User Id (usually username) of the logged in operator.
    /// </summary>
    public string OriginUserId { get; set; }

    /// <summary>
    /// Host name of a computer where message is generated (usually it's NetBIOS name).
    /// </summary>
    public string OriginHost { get; set; }

    /// <summary>
    /// If LIS supports locations, <see cref="Location"/> where event is generated.
    /// </summary>
    public Location OriginLocation { get; set; }

}
