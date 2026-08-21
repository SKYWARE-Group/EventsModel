namespace Skyware.Lis.EventsModel.Payments;


/// <summary>
/// Represents fiscal receipt issued for given <see cref="Payment"/>
/// </summary>
public class Receipt
{

    /// <summary>
    /// Serial number of the fiscal device the receipt is printed to
    /// </summary>
    public string MemorySerialNumber { get; set; }

    /// <summary>
    /// Number of the receipt (usually it is sequence number for given device)
    /// </summary>
    public string ReceiptNumber { get; set; }

}
