using AccessToDb;
using Fait.DAL;
using Fait.LogicObjects.DTO;
using Fait.LogicObjects.Enums;
using System;
using System.Collections.Generic;

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
                MaritalStatus = studentCard.MaritalStatusId,
                Registration = studentCard.Registration,
                Exemption = studentCard.Exemption,
                ExpirienceCompetition = studentCard.ExpirienceCompetitionId,
                TransferFrom = studentCard.TransferFrom,
                TransferDirection = studentCard.TransferDirection,
                CompetitionConditions = studentCard.CompetitionConditions,
                OutOfCompetitionInfo = studentCard.OutOfCompetitionInfo,
                Ammends = studentCard.AmmendsId,
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
                StudentState = studentCard.StudStateId
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
