using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class StudentCardModel
    {
        //public string Faculty { get; set; }
        //public string Group { get; set; }
        //public string LevelOfStudying { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthPlace  { get; set; }//Місце народження
        public string Immenseness { get; set; } //Громадянство 
        public string MaritalStatus { get; set; }//Сімейний стан
        public string Registration { get; set; }//Місце проживання\регістрації
        public string Exemption { get; set; }//Наявність пільг при втсупі
        public int OrderNumber { get; set; } //Номер наказу 
        public DateTime OrderDate { get; set; } //Дата наказу
        public int EmploymentNumber { get; set; }// код рабочей кнжики
        public string EmploymentAuthority { get; set; }// кто выдал рабочую книжку
        public DateTime EmploymentGivenDate { get; set; } //дата ее выдачи
        public string RegistrOrPassportNumber { get; set; }// код регистарции или серия и номер паспорта
        public string StudState { get; set; }// состояние студента
    }
}
