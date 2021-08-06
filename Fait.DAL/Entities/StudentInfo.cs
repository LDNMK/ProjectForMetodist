using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentInfo
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthPlace { get; set; }
        public byte DegreeId { get; set; }
        public string Citizenship { get; set; }
        public string GraduatedSchoolName { get; set; }
        public int? GraduatedYear { get; set; }
        public byte MaritalStatusId { get; set; }
        public string Registration { get; set; }
        public string Exemption { get; set; }
        public byte ExperienceCompetitionId { get; set; }
        public string TransferFrom { get; set; }
        public string TransferDirection { get; set; }
        public string CompetitionConditions { get; set; }
        public string OutOfCompetitionInfo { get; set; }
        public byte AmendsId { get; set; }
        public int? EmploymentNumber { get; set; }
        public string EmploymentAuthority { get; set; }
        public DateTime? EmploymentGivenDate { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string RegistrOrPassportNumber { get; set; }

        public virtual Amend Amends { get; set; }
        public virtual Degree Degree { get; set; }
        public virtual ExperienceCompetition ExperienceCompetition { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
    }
}
