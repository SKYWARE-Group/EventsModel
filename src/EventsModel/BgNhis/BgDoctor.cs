// Ignore Spelling: bg

using Skyware.Lis.EventsModel.Common;

namespace Skyware.Lis.EventsModel.BgNhis;


/// <summary>
/// Doctor, according to Bulgarian regulations (inherits <see cref="Doctor"/>)
/// </summary>
public class BgDoctor : Doctor
{

    /// <summary>
    /// Speciality code, according to NHIF
    /// </summary>
    public string NhifSpecialityCode { get; set; }

    /// <summary>
    /// Speciality code, according to NHIS (CL006)
    /// </summary>
    public string NhisSpecialityCode { get; set; }


}
