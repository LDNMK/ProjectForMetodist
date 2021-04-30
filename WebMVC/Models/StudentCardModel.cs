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

        public string BirthPlace  { get; set; }
        //Громадянство 
        public string Immenseness { get; set; }
        public string MaritalStatus { get; set; }
        public string Registartion { get; set; }
        public string Exemption { get; set; }
        public int OrderNumber { get; set; }
        // TODO:Хранение даты приказа, 9-ки
        public int EmploymentNumber { get; set; }
        public string EmploymentAuthority { get; set; }
        public string EmploymentLocation { get; set; }
        public string TaxPassportNumber { get; set; }
        public string State { get; set; }
    }
}
