namespace Skyware.Lis.EventsModel.Payments;


/// <summary>
/// Event. Occurs when a payment is made 
/// Default address: topic://instruments/queries
/// </summary>
public class Payment : BaseMessage
{

    /// <summary>
    /// Default address where messages are produced
    /// </summary>
    public override string DefaultAddress => "topic://payments";

    /// <summary>
    /// Id of the payment in LIS iLab
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// Sale to which payment is associated
    /// </summary>
    public int SaleId { get; set; }

    /// <summary>
    /// Shift on which the payment is made
    /// </summary>
    public Shift Shift { get; set; }

    /// <summary>
    /// Type of payment (<see cref="PaymentType"/>
    /// </summary>
    public PaymentType PaymentType { get; set; }

    /// <summary>
    /// The amount. Negative values represent refunds
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// <see cref="Receipt"/> from fiscal device, if such is printed on connected device
    /// </summary>
    public Receipt Receipt { get; set; }

    /// <summary>
    /// <see cref="CardTransaction"/>, if payment is made trough connected terminal
    /// </summary>
    public CardTransaction CardTransaction { get; set; }

}
