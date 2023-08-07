namespace Skyware.Lis.EventsModel.Payments;


/// <summary>
/// Represents payment type, such as "Cash", ""Voucher", etc.
/// </summary>
public class PaymentType
{

    /// <summary>
    /// Identifier of the type according to LIS iLab
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Descriptive name of the payment
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// If the payment is in cash
    /// </summary>
    public bool IsCash { get; set; }

}
