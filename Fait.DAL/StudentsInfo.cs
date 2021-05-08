using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentsInfo
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }//дата рождения
        public string BirthPlace { get; set; }//место рождения
        public string Immenseness { get; set; }//гражданство
        public byte? MaritalStatus { get; set; }//семейное состояние
        public string Registration { get; set; }//место регистрации
        public string Exemption { get; set; }//пілги при вступе
        public byte? ExpirienceCompetition { get; set; }//ссылка на опыт рабты
        public string TransferFrom { get; set; }//университет с которого перевод
        public string TransferDirection { get; set; }//направление перевода
        public string CompetitionConditions { get; set; }//особые условия конкурса
        public string OutOfCompetitionInfo { get; set; }//поза конкуром
        public byte? Ammends { get; set; }//пільги
        public int? EmploymentNumber { get; set; }//номер рабочей книжки
        public string EmploymentAuthority { get; set; }//хто выдал
        public DateTime? EmploymentGivenDate { get; set; }// дата выдачи
        public string RegistrOrPassportNumber { get; set; }//номер регистрации или код и сероия паспорта

        public virtual Ammende AmmendsNavigation { get; set; }
        public virtual ExpirienceCompetitione ExpirienceCompetitionNavigation { get; set; }
        public virtual Student IdNavigation { get; set; }
        public virtual MaritalStatus MaritalStatusNavigation { get; set; }
    }
}
