// Ignore Spelling: nrn lrn

using Skyware.Lis.EventsModel.Common;
using System;
using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.BgNhis;


/// <summary>
/// Represent e-referral from Bulgarian NHIS (form #4 of MoH)
/// </summary>
public class Referral
{

    /// <summary>
    /// Identifier in the LIS iLab (null if it is never imported)
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Unique identifier of the referral in Bulgarian NHIS
    /// </summary>
    public string Nrn { get; set; }

    /// <summary>
    /// Issuer's identifier
    /// </summary>
    public string Lrn { get; set; }

    /// <summary>
    /// The Rila channel the referral is read, locked or unlocked (null if Arda is used)
    /// </summary>
    public int? RilaId { get; set; }

    /// <summary>
    /// Date of issuance
    /// </summary>
    public DateTime Issued { get; set; }

    /// <summary>
    /// Regulatory bound date which corresponds with NHIF reports (date of sampling)
    /// </summary>
    public DateTime VisitDate { get; set; }

    /// <summary>
    /// Regulatory bound date which corresponds with NHIF reports (date of results)
    /// </summary>
    public DateTime ExecutionDate { get; set; }

    /// <summary>
    /// RHIF region of the patient, according NHIF
    /// </summary>
    public string RhifRegion { get; set; }

    /// <summary>
    /// Health region if the patient, according to NHIF
    /// </summary>
    public string HealthRegion { get; set; }

    /// <summary>
    /// Payer institution, typed value, according to NHIS
    /// </summary>
    public int FinancingSource { get; set; }

    /// <summary>
    /// Patient's <see cref="Diagnosis"/> as a reason for referral issuance
    /// </summary>
    public Diagnosis Diagnosis { set; get; }

    /// <summary>
    /// <see cref="Patient"/> to which referral is issued
    /// </summary>
    public Patient Patient { get; set; }

    /// <summary>
    /// Practitioner (<see cref="BgDoctor"/>), who issued the referral
    /// </summary>
    public BgDoctor Issuer { get; set; }

    /// <summary>
    /// <see cref="MedicalPractice"/> of the issuing doctor
    /// </summary>
    public MedicalPractice IssuerPractice { get; set; }

    /// <summary>
    /// Responsible doctor (<see cref="BgDoctor"/>, the one who is will perform examinations)
    /// </summary>
    public BgDoctor LaboratoryDoctor { get; set; }

    /// <summary>
    /// Collection of <see cref="NhisExamination"/>, ordered with this referral
    /// </summary>
    public IEnumerable<NhisExamination> Items { get; set; }

}
