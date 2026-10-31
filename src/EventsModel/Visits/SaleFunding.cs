using Skyware.Lis.EventsModel.Common;

namespace Skyware.Lis.EventsModel.Visits;

/// <summary>
/// Funds (insurance funds or clinics, Фонд/Клиника 1 and 2) of a <see cref="Sale"/>, as saved and as they were before the save.
/// </summary>
/// <remarks>
/// A fund that is not set is null. A fund whose previous value equals the current one has not been changed by the
/// operation of the message; a different identifier means it was set, replaced or cleared.
/// </remarks>
public class SaleFunding
{

    /// <summary>
    /// Fund 1 of the visit after the operation; null when the visit has no fund 1.
    /// </summary>
    public Organization Fund1 { get; set; }

    /// <summary>
    /// Fund 2 of the visit after the operation; null when the visit has no fund 2.
    /// </summary>
    public Organization Fund2 { get; set; }

    /// <summary>
    /// Fund 1 of the visit before the operation; null when it had none, and always null for a created visit.
    /// </summary>
    public Organization PreviousFund1 { get; set; }

    /// <summary>
    /// Fund 2 of the visit before the operation; null when it had none, and always null for a created visit.
    /// </summary>
    public Organization PreviousFund2 { get; set; }

}
