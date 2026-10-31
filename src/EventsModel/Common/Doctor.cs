using System.Text.Json.Serialization;

namespace Skyware.Lis.EventsModel.Common;


/// <summary>
/// Represent medical doctor (inherits <see cref="Person"/>)
/// </summary>
[JsonDerivedType(typeof(BgNhis.BgDoctor))]
public class Doctor : Person
{

    /// <summary>
    /// Identifier in the LIS iLab
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Professional identifier issued by national or local healthcare authorities
    /// </summary>
    public string Identifier { get; set; }


}
