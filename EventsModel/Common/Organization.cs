using System.Text.Json.Serialization;

namespace Skyware.Lis.EventsModel.Common;


/// <summary>
/// Represents partner organization - Insurance fund, Clinic or medical practice
/// </summary>
[JsonDerivedType(typeof(BgNhis.MedicalPractice))]
public class Organization
{

    /// <summary>
    /// Identifier in the LIS iLab
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of organization
    /// </summary>
    public string Name { get; set; }

}
