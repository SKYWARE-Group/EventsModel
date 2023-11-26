namespace Skyware.Lis.EventsModel.Payments;


/// <summary>
/// Receptionist's shift
/// </summary>
public class Shift
{

    /// <summary>
    /// Id of the shift in LIS iLab
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Username of the owner of the shift
    /// </summary>
    public string CashierId { get; set; }

}
