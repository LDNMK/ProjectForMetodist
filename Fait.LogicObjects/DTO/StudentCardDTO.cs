using System;

namespace Fait.LogicObjects.DTO
{
    public class StudentCardDTO
    {
        //public string Faculty { get; set; }
        //public string Group { get; set; }
        //public string LevelOfStudying { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string Immenseness { get; set; } //Громадянство 
        public string MaritalStatus { get; set; }
        public string Registration { get; set; }
        public string Exemption { get; set; }
        public int OrderNumber { get; set; } //Номер наказу 
        public DateTime OrderDate { get; set; } //Дата наказу
        public int EmploymentNumber { get; set; }
        public string EmploymentAuthority { get; set; }
        public DateTime EmploymentGivenDate { get; set; }
        public string RegistrOrPassportNumber { get; set; }
        public string StudState { get; set; }
    }
}
