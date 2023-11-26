namespace Skyware.Lis.EventsModel.Common;

/// <summary>
/// Represent sale schema
/// </summary>
public class SaleSchema
{

    /// <summary>
    /// PK in the database
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the sale schema
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 1=Standard, 2=NHIF
    /// </summary>
    public int SchemaType { get; set; }

}
