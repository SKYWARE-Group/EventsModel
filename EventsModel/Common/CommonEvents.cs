namespace Skyware.Lis.EventsModel.Common;

/// <summary>
/// Common event types
/// </summary>
public class CommonEvents
{

    /// <summary>
    /// New referral is imported
    /// </summary>
    public const string CREATED = "Created";

    /// <summary>
    /// The imported referral is locked in NHIS
    /// </summary>
    public const string UPDATED = "Updated";

    /// <summary>
    /// The imported referral is unlocked in NHIS
    /// </summary>
    public const string DELETED = "Deleted";


}
