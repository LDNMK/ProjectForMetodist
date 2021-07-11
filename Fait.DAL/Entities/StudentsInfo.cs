using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentsInfo
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthPlace { get; set; }
        public int DegreeId { get; set; }
        public string Immenseness { get; set; }
        public byte? MaritalStatusId { get; set; }
        public string Registration { get; set; }
        public string Exemption { get; set; }
        public byte? ExpirienceCompetitionId { get; set; }
        public string TransferFrom { get; set; }
        public string TransferDirection { get; set; }
        public string CompetitionConditions { get; set; }
        public string OutOfCompetitionInfo { get; set; }
        public int? AmendId { get; set; }
        public int? EmploymentNumber { get; set; }
        public string EmploymentAuthority { get; set; }
        public DateTime? EmploymentGivenDate { get; set; }
        public string RegistrOrPassportNumber { get; set; }

        public virtual Amend Amend { get; set; }
        public virtual Degree Degree { get; set; }
        public virtual ExperienceCompetition ExpirienceCompetition { get; set; }
        public virtual Student Student { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
    }
}
