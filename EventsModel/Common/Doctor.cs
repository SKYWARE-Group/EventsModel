namespace Skyware.Lis.EventsModel.Common;


/// <summary>
/// Represent medical doctor (inherits <see cref="Person"/>)
/// </summary>
public class Doctor : Person
{

    /// <summary>
    /// Identifier in the LIS iLab
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Professional identifier issued by national or local authorities
    /// </summary>
    public string Identifier { get; set; }


}
