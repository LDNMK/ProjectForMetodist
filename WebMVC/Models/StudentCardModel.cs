using System;
using System.Collections.Generic;
using WebAPI.Models.Transfer;

namespace WebAPI.Models
{
    public class StudentCardModel
    {
        public int Course { get; set; }
        public int GroupId { get; set; }
        public int GroupYear { get; set; }
        public byte DegreeId { get; set; }
        public int SpecialityId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Birthdate { get; set; }
        public string BirthPlace { get; set; }              // Місце народження
        public string Citizenship { get; set; }             // Громадянство 
        public string GraduatedSchoolName { get; set; }
        public int GraduatedYear { get; set; }
        public string Registration { get; set; }            // Місце проживання\регістрації
        public string Exemption { get; set; }               // Наявність пільг при втсупі
        public byte MaritalStatusId { get; set; }
        public byte ExperienceCompetitionId { get; set; }
        public string TransferFrom { get; set; }
        public string TransferDirection { get; set; }
        public string CompetitionConditions { get; set; }
        public string OutOfCompetitionInfo { get; set; }
        public string OrderNumber { get; set; }                // Номер наказу 
        public string OrderDate { get; set; }               // Дата наказу
        public int? EmploymentNumber { get; set; }           // Код рабочей книжки
        public string EmploymentAuthority { get; set; }     // Кто выдал рабочую книжку
        public string EmploymentGivenDate { get; set; }     // Дата ее выдачи
        public byte AmendsId { get; set; }
        public string RegistrOrPassportNumber { get; set; } // Код регистарции или серия и номер паспорта
        public int? StudentStateId { get; set; }            // Состояние студента

        public ICollection<StudentTransferHistoryModel> TransferHistory { get; set; }
    }
}
