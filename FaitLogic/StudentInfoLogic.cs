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
        private AccessForLogic accessStudentInfo { get; set; } = new AccessForLogic();
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
                MaritalStatusId = studentCard.MaritalStatusId,
                Registration = studentCard.Registration,
                Exemption = studentCard.Exemption,
                ExpirienceCompetitionId = studentCard.ExpirienceCompetitionId,
                TransferFrom = studentCard.TransferFrom,
                TransferDirection = studentCard.TransferDirection,
                CompetitionConditions = studentCard.CompetitionConditions,
                OutOfCompetitionInfo = studentCard.OutOfCompetitionInfo,
                AmmendsId = studentCard.AmmendsId,
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

        public ICollection<string> GetListOfGroups()
        {
            return accessStudentInfo.GetAllGroups();
        }

        public ICollection<string> GetListOfStudents(string group)
        {
            var array = group.Split('-');
            var groupNumber = Convert.ToInt32(array[1]);
            var groupNameId = accessStudentInfo.FindGroupNameId(array[1]);
            return accessStudentInfo.GetAllStudents(groupNumber, groupNameId);
        }

        public ICollection<string> GetStudentInfo(int studentId)
        {
            return new List<string>();//accessStudentInfo.GetAllStudents(studentId);
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
