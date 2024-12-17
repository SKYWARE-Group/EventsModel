using System.Text.Json.Serialization;

namespace Skyware.Lis.EventsModel.Common;


/// <summary>
/// Abstract object representing a person
/// </summary>
[JsonDerivedType(typeof(Common.Doctor))]
[JsonDerivedType(typeof(Common.Patient))]
[JsonDerivedType(typeof(BgNhis.BgDoctor))]
public abstract class Person
{

    /// <summary>
    /// First (given) name
    /// </summary>
    public string GivenName { get; set; }

    /// <summary>
    /// Second name or initials
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// Last (family) name
    /// </summary>
    public string FamilyName { get; set; }


}
