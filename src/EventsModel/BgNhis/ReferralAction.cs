// Ignore Spelling: bg

namespace Skyware.Lis.EventsModel.BgNhis;

/// <summary>
/// Occurs when action with a <see cref="Referral"/> is made
/// </summary>
public class ReferralAction : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://bg-nhis/referrals";

    /// <summary>
    /// Action made with the referral, according to <see cref="ReferralEvents"/>
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// Sale to which referral is imported
    /// </summary>
    public int? SaleId { get; set; }

    /// <summary>
    /// Sale schema of the Sale to which referral is imported
    /// </summary>
    public int? SchemaId { get; set; }

    /// <summary>
    /// Imported/Removed <see cref="Referral"/>
    /// </summary>
    public Referral Referral { get; set; }

}
