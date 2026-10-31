namespace Skyware.Lis.EventsModel.Orders;

/// <summary>
/// Occurs when operation with <see cref="Order"/> is made
/// </summary>
public class OrderAction : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://orders";

    /// <summary>
    /// <see cref="Order"/>, the subject of the event
    /// </summary>
    public Order Order { get; set; }

    /// <summary>
    /// Action made with the order, according to <see cref="OrderEvents"/>
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// Sale Id, in case order is imported
    /// </summary>
    public int? SaleId { get; set; }

    /// <summary>
    /// Reason, in case of order rejection
    /// </summary>
    public string RejectionReason { get; set; }

}
