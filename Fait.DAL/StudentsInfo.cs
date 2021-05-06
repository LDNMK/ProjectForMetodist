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
        public string Immenseness { get; set; }
        public byte? MaritalStatus { get; set; }
        public string Registration { get; set; }
        public string Exemption { get; set; }
        public byte? ExpirienceCompetition { get; set; }
        public string TransferFrom { get; set; }
        public string TransferDirection { get; set; }
        public string CompetitionConditions { get; set; }
        public string OutOfCompetitionInfo { get; set; }
        public byte? Ammends { get; set; }
        public int? EmploymentNumber { get; set; }
        public string EmploymentAuthority { get; set; }
        public DateTime? EmploymentGivenDate { get; set; }
        public string RegistrOrPassportNumber { get; set; }

        public virtual Ammende AmmendsNavigation { get; set; }
        public virtual ExpirienceCompetitione ExpirienceCompetitionNavigation { get; set; }
        public virtual Student IdNavigation { get; set; }
        public virtual MaritalStatus MaritalStatusNavigation { get; set; }
    }
}
