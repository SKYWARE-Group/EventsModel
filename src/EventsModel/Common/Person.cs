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

    /// <summary>
    /// Type of the event (see <see cref="CommonEvents"/>), i.e. whether the record of the person itself was created or updated.
    /// </summary>
    /// <remarks>
    /// Null when the producer of the message does not track changes of the person.
    /// </remarks>
    public string EventType { get; set; }

}
