using System;
using System.Collections.Generic;
using WebAPI.Models.Transfer;

namespace WebAPI.Models
{
    public class StudentCardModel
    {
        public int? Course { get; set; }
        public int? GroupId { get; set; }
        public int? GroupYear { get; set; }
        public int? DegreeId { get; set; }
        public int? SpecialityId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthPlace { get; set; }              // Місце народження
        public string Citizenship { get; set; }             // Громадянство // Change to Citizenship
        public byte? MaritalStatusId { get; set; }          // Сімейний стан
        public string Registration { get; set; }            // Місце проживання/регістрації
        public string Exemption { get; set; }               // Наявність пільг при вступі
        public byte? ExperienceCompetitionId { get; set; }
        public string TransferFrom { get; set; }
        public string TransferDirection { get; set; }
        public string CompetitionConditions { get; set; }
        public string OutOfCompetitionInfo { get; set; }
        public int? AmendsId { get; set; }
        public int? OrderNumber { get; set; }                // Номер наказу 
        public DateTime? OrderDate { get; set; }               // Дата наказу
        public int? EmploymentNumber { get; set; }           // Код рабочей книжки
        public string EmploymentAuthority { get; set; }     // Кто выдал рабочую книжку
        public DateTime? EmploymentGivenDate { get; set; }     // Дата ее выдачи
        public string RegistrOrPassportNumber { get; set; } // Код регистарции или серия и номер паспорта
        public int? StudentStateId { get; set; }            // Состояние студента

        public ICollection<StudentTransferHistoryModel> TransferHistory { get; set; }
    }
}
