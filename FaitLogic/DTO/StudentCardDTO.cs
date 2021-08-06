using System;
﻿using System.Collections.Generic;

namespace FaitLogic.DTO
{
    public class StudentCardDTO
    {
        public int Course { get; set; }
        public int GroupId { get; set; }
        public int GroupYear { get; set; }
        public byte DegreeId { get; set; }
        public int SpecialityId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthdate { get; set; }
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
        public byte AmendsId { get; set; }
        public int? EmploymentNumber { get; set; }
        public string EmploymentAuthority { get; set; }
        public DateTime? EmploymentGivenDate { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string RegistrOrPassportNumber { get; set; } // Код регистарции или серия и номер паспорта
        public int? StudentStateId { get; set; }             // Состояние студента

        public ICollection<StudentTransferHistoryDTO> TransferHistory { get; set; }
    }
}
