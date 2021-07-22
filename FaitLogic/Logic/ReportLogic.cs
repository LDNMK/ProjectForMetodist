using AutoMapper;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DictionariesWithValues;
using FaitLogic.DTO;
using FaitLogic.Enums;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FaitLogic.Logic
{
    public class ReportLogic
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork unitOfWork;

        public ReportLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        // TO DO: make enum for speciality
        public void CreateReport(StudentCardDTO studentInfoDto, ICollection<StudentProgressDTO> studentProgresses)
        {
            var orderDate = studentInfoDto.OrderDate;
            var studentInfo = new Dictionary<string, string>();
            studentInfo.Add("Degree", DictionaryWithValues.Degrees[studentInfoDto.DegreeId]);
            //studentInfo.Add("SpecialityId", studentInfo.SpecialityName);
            studentInfo.Add("Specialization", studentInfoDto.Specialization);
            studentInfo.Add("Name", string.Format("{0} {1} {2}", studentInfoDto.LastName, studentInfoDto.FirstName, studentInfoDto.Patronymic));
            studentInfo.Add("Birthday", studentInfoDto.Birthday);
            studentInfo.Add("BirthPlace", studentInfoDto.BirthPlace);
            studentInfo.Add("Citizenship", studentInfoDto.Citizenship);
            studentInfo.Add("MaritalStatus", DictionaryWithValues.MaritalStatus[studentInfoDto.MaritalStatusId.Value]);
            studentInfo.Add("Registration", studentInfoDto.Registration);
            studentInfo.Add("Exemption", studentInfoDto.Exemption);
            studentInfo.Add("ExpirienceCompetition", DictionaryWithValues.ExperienceCompetition[studentInfoDto.ExpirienceCompetitionId.Value]);
            studentInfo.Add("TransferFrom", studentInfoDto.TransferFrom);
            studentInfo.Add("TransferDirection", studentInfoDto.TransferDirection);
            studentInfo.Add("CompetitionConditions", studentInfoDto.CompetitionConditions);
            studentInfo.Add("OutOfCompetitionInfo", studentInfoDto.OutOfCompetitionInfo);
            studentInfo.Add("Amend", DictionaryWithValues.Ammends[studentInfoDto.AmendId.Value]);
            studentInfo.Add("OrderNumber", studentInfoDto.OrderNumber.ToString());
            studentInfo.Add("OrderDate", string.Format("\"{0}\" {1} {2} року", orderDate.Day.ToString().PadLeft(2, '0'), orderDate.ToMonthName(), orderDate.Year));
            studentInfo.Add("Employment", string.Format("{0} {1} {2}",studentInfoDto.EmploymentNumber.ToString(), studentInfoDto.EmploymentGivenDate, studentInfoDto.EmploymentAuthority));
            studentInfo.Add("RegistrOrPassportNumber", studentInfoDto.RegistrOrPassportNumber);

            CreateDocument(studentInfo, studentProgresses);
        }

        private void CreateDocument(Dictionary<string, string> studentInfo, ICollection<StudentProgressDTO> studentProgresses)
        {
            Application application = new Application();
            Document document = new Document();

            Object missingObj = System.Reflection.Missing.Value;
            Object falseObj = false;


            Object documentPath = @"C:\Users\agurz\source\ProjectForMetodist\FaitLogic\WordDocument\НАВЧАЛЬНА_КАРТКА_СТУДЕНТА.doc";
            try
            {
                document = application.Documents.Add(ref documentPath, ref missingObj, ref missingObj, ref missingObj);
            }
            catch (Exception error)
            {
                document.Close(ref falseObj, ref missingObj, ref missingObj);
                application.Quit(ref missingObj, ref missingObj, ref missingObj);
                document = null;
                application = null;
                throw;
            }

            for (int i = 1; i <= document.Bookmarks.Count; i++)
            {
                var bookmark = document.Bookmarks[i];
                Microsoft.Office.Interop.Word.Range bookmarkRange = bookmark.Range;

                bookmarkRange.Text = studentInfo[bookmark.Name];
                bookmarkRange.Underline = WdUnderline.wdUnderlineSingle;
            }


            application.Visible = true;

            document.Save();
            document.Close(ref falseObj, ref missingObj, ref missingObj);
            application.Quit(ref missingObj, ref missingObj, ref missingObj);
        }
    }
}
