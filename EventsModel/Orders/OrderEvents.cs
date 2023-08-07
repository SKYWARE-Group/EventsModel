namespace Skyware.Lis.EventsModel.Orders;


/// <summary>
/// Well-known values for order events 
/// </summary>
public class OrderEvents
{

    /// <summary>
    /// New order is created
    /// </summary>
    public const string CREATED = "Created";

    /// <summary>
    /// Existing order is updated
    /// </summary>
    public const string UPDATED = "Updated";

    /// <summary>
    /// Existing order is canceled (deleted)
    /// </summary>
    public const string CANCELED = "Canceled";

    /// <summary>
    /// Order is imported (locked)
    /// </summary>
    public const string IMPORTED = "Imported";

    /// <summary>
    /// Order is rejected from the laboratory
    /// </summary>
    public const string REJECTED = "Rejected";

}
