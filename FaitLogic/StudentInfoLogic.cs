using AccessToDb;
using Fait.DAL;
using Fait.DTO;
using System;

namespace FaitLogic
{
    public class StudentInfoLogic
    {
        private AccessStudentInfo accessStudentInfo { get; set; } = new AccessStudentInfo();
        public void AddStudentInfo(StudentCardDTO studentCard)
        {
            var isValid = ValidateStudentCard(studentCard);
            if (!isValid)
            {
                return;
            }

            var studentInfo = new StudentsInfo
            {
                Birthdate = studentCard.Birthday,
                BirthPlace = studentCard.BirthPlace,
                Immenseness = studentCard.Immenseness,
                //MaritalStatus = studentCard.MaritalStatus,
                Registartion = studentCard.Registartion,
                Exemption = studentCard.Exemption,
                //Competition = studentCard.C,
                //FromIns = studentCard.,
                //Direction = studentCard.Birthday,
                //Uniq = studentCard.OrderNumber,
                //NoCompetititon = studentCard.Birthday,
                //Ammends = studentCard.A,
                EmploymentNumber = studentCard.EmploymentNumber,
                EmploymentAuthority = studentCard.EmploymentAuthority,
                //EmploymentGivenDate = studentCard.,
                RegistrOrPassportNumber = studentCard.TaxPassportNumber
            };

            accessStudentInfo.AddStudentInfoToDb(studentInfo);
        }

        private bool ValidateStudentCard(StudentCardDTO studentCard)
        {
            if (studentCard.Name == null && studentCard.Name == "")
            {
                return false;
            }
            return true;
        }
    }
}
