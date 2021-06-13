using System;

namespace Fait.DAL
{
    public partial class StudentsInfo
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }             // Дата рождения
        public string BirthPlace { get; set; }              // Место рождения
        public string Immenseness { get; set; }             // Гражданство
        public byte? MaritalStatusId { get; set; }          // Семейное состояние
        public string Registration { get; set; }            // Место регистрации
        public string Exemption { get; set; }               // Льготы при вступе
        public byte? ExpirienceCompetitionId { get; set; }  // Ссылка на опыт рабты
        public string TransferFrom { get; set; }            // Университет с которого перевод
        public string TransferDirection { get; set; }       // Направление перевода
        public string CompetitionConditions { get; set; }   // Особые условия конкурса
        public string OutOfCompetitionInfo { get; set; }    // Поза конкуром
        public int? AmendId { get; set; }                   // пільги ??
        public int? EmploymentNumber { get; set; }          // Номер рабочей книжки
        public string EmploymentAuthority { get; set; }     // Кто выдал
        public DateTime? EmploymentGivenDate { get; set; }  // Дата выдачи
        public string RegistrOrPassportNumber { get; set; } // Номер регистрации или код и сероия паспорта

        public virtual Amend Amend { get; set; }
        public virtual ExperienceCompetition ExpirienceCompetition { get; set; }
        public virtual Student Student { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
    }
}
