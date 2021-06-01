using System;

namespace Fait.DAL
{
    public partial class StudentsInfo
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }//дата рождения
        public string BirthPlace { get; set; }//место рождения
        public string Immenseness { get; set; }//гражданство
        public byte? MaritalStatusId { get; set; }//семейное состояние
        public string Registration { get; set; }//место регистрации
        public string Exemption { get; set; }//пілги при вступе
        public byte? ExpirienceCompetitionId { get; set; }//ссылка на опыт рабты
        public string TransferFrom { get; set; }//университет с которого перевод
        public string TransferDirection { get; set; }//направление перевода
        public string CompetitionConditions { get; set; }//особые условия конкурса
        public string OutOfCompetitionInfo { get; set; }//поза конкуром
        public byte? AmmendsId { get; set; }//пільги
        public int? EmploymentNumber { get; set; }//номер рабочей книжки
        public string EmploymentAuthority { get; set; }//хто выдал
        public DateTime? EmploymentGivenDate { get; set; }// дата выдачи
        public string RegistrOrPassportNumber { get; set; }//номер регистрации или код и сероия паспорта

        public virtual Ammende Ammends { get; set; }
        public virtual ExpirienceCompetitione ExpirienceCompetition { get; set; }
        public virtual Student Student { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
    }
}
