namespace Skyware.Lis.EventsModel.BgNhis;

/// <summary>
/// Well-known values for referral events 
/// </summary>
public class ReferralEvents
{

    /// <summary>
    /// New referral is imported
    /// </summary>
    public const string IMPORTED = "Imported";

    /// <summary>
    /// The imported referral is locked in NHIS
    /// </summary>
    public const string LOCKED = "Locked";

    /// <summary>
    /// The imported referral is unlocked in NHIS
    /// </summary>
    public const string UNLOCKED = "Unlocked";

    /// <summary>
    /// Referral is removed (deleted)
    /// </summary>
    public const string REMOVED = "Removed";

}
