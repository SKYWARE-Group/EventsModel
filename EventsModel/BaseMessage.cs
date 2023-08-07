using Skyware.Lis.EventsModel.Common;
using System;

namespace Skyware.Lis.EventsModel;


/// <summary>
/// Base class for all messages produced by LIS iLab
/// </summary>
public abstract class BaseMessage
{

    /// <summary>
    /// Default address where message should be send
    /// </summary>
    public abstract string DefaultAddress { get; }

    /// <summary>
    /// Id of the message, GUID
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Date and time when message is generated
    /// </summary>
    public DateTime EventTime { get; set; } = DateTime.Now;

    /// <summary>
    /// Origin application name
    /// </summary>
    public string OriginApp { get; set; }

    /// <summary>
    /// Origin application version
    /// </summary>
    public string OriginAppVer { get; set; }

    /// <summary>
    /// User Id (usually username) of the logged in operator
    /// </summary>
    public string OriginUserId { get; set; }

    /// <summary>
    /// Host name of a computer where message is generated (usually it's NetBIOS name)
    /// </summary>
    public string OriginHost { get; set; }

    /// <summary>
    /// If LIS supports locations, <see cref="Location"/> where event is generated
    /// </summary>
    public Location OriginLocation { get; set; }


}
