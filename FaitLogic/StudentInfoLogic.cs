using AccessToDb;
using Fait.DAL;
using Fait.LogicObjects.DTO;
using System;

namespace FaitLogic
{
    public class StudentInfoLogic
    {
        private AccessStudentCard accessStudentInfo { get; set; } = new AccessStudentCard();
        public void AddStudentCardInfo(StudentCardDTO studentCard)
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
                Registration = studentCard.Registration,
                Exemption = studentCard.Exemption,
                //Competition = studentCard.C,
                //FromIns = studentCard.,
                //Direction = studentCard.Birthday,
                //Uniq = studentCard.OrderNumber,
                //NoCompetititon = studentCard.Birthday,
                //Ammends = studentCard.A,
                EmploymentNumber = studentCard.EmploymentNumber,
                EmploymentAuthority = studentCard.EmploymentAuthority,
                EmploymentGivenDate = studentCard.EmploymentGivenDate,
                RegistrOrPassportNumber = studentCard.RegistrOrPassportNumber
            };
            var student = new Student
            {
                //SpecialityId = studentCard.
                FirstName = studentCard.Name,
                LastName = studentCard.Surname,
                Patronymic = studentCard.Patronymic,
                //StudState = studentCard.StudState
            };

            accessStudentInfo.AddStudentCardToDb(studentInfo, student);
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
