using AutoMapper;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DictionariesWithValues;
using FaitLogic.DTO;
using FaitLogic.Enums;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void CreateReport(StudentCardDTO studentInfoDto, ICollection<StudentProgressDTO> studentProgresses)
        {
            var orderDate = studentInfoDto.OrderDate.Value;
            var studentInfo = new Dictionary<string, string>();
            studentInfo.Add("Degree", DictionaryWithValues.Degrees[studentInfoDto.DegreeId.Value]);
            studentInfo.Add("Speciality", DictionaryWithValues.Specialities[studentInfoDto.SpecialityId.Value]);
            studentInfo.Add("Specialization", studentInfoDto.Specialization);
            studentInfo.Add("Name", string.Format("{0} {1} {2}", studentInfoDto.LastName, studentInfoDto.FirstName, studentInfoDto.Patronymic));
            studentInfo.Add("Birthday", studentInfoDto.Birthdate.ToString("dd.MM.yyyy"));
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
            studentInfo.Add("Employment", 
                string.Format("{0} {1} {2}", 
                    studentInfoDto.EmploymentNumber.ToString(), 
                    studentInfoDto.EmploymentGivenDate.GetValueOrDefault().ToString("dd.MM.yyyy"), 
                    studentInfoDto.EmploymentAuthority));
            studentInfo.Add("RegistrOrPassportNumber", studentInfoDto.RegistrOrPassportNumber);

            CreateDocument(studentInfo, studentProgresses);
        }

        private void CreateDocument(Dictionary<string, string> studentInfo, ICollection<StudentProgressDTO> studentProgresses)
        {
            Application application = new Application();
            Document document = new Document();

            object missingObj = Missing.Value;
            object falseObj = false;

            var path = Directory.GetParent(Directory.GetCurrentDirectory());
            object documentPath = Path.Join(path.FullName, "\\FaitLogic\\WordDocument\\НАВЧАЛЬНА_КАРТКА_СТУДЕНТА.doc");
            try
            {
                document = application.Documents.Add(ref documentPath, ref missingObj, ref missingObj, ref missingObj);
            }
            catch (Exception e)
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

            Table table = document.Tables[2];

            var rows = new Dictionary<int, int[]>()
            {
                //key - course, value - {Autumn, Spring}
                { 1, new int[] {4, 20 } },
                { 2, new int[] {37, 59 } },
                { 3, new int[] {78, 95 } },
                { 4, new int[] {114, 132 } },
                { 5, new int[] {150, 168 } },
                { 6, new int[] {186, 204 } }
            };

            foreach (var studentProgress in studentProgresses)
            {
                var courseSemesters = rows[studentProgress.Course];

                FillYear(studentProgress, table, courseSemesters[0], courseSemesters[1]); // 0 - Autumn, 1 - Spring
            }

            application.Visible = true;

            application.Quit(ref missingObj, ref missingObj, ref missingObj);
        }

        private static string ChooseRow(int column, int semester, StudentSubjectDTO subject)
        {
            return column switch
            {
                3 => subject.Name,
                4 => subject.Hours.ToString(),
                5 => subject.Ects.ToString(),
                6 => subject.SubjectSemesters.Single(x => x.Semester == semester).Mark.ToString(),
                9 => subject.SubjectSemesters.Single(x => x.Semester == semester).ModifiedOn.ToString("dd.MM.yyyy"),
                _ => throw new ArgumentException()
            };
        }

        private static void FillYear(StudentProgressDTO studentProgress, Table table, int rowAutumn, int rowSpring)
        {
            foreach (var subject in studentProgress.Subjects)
            {
                FillSemester(subject, table, ref rowAutumn, (int)SemesterEnum.Autumn);
                FillSemester(subject, table, ref rowSpring, (int)SemesterEnum.Spring);
            }
        }

        private static void FillSemester(StudentSubjectDTO subject, Table table, ref int row, int semester)
        {
            if (subject.SubjectSemesters.Any(x => x.Semester == semester))
            {
                Microsoft.Office.Interop.Word.Range cellRange;
                for (int column = 3; column < 7; column++)
                {
                    cellRange = table.Cell(row, column).Range;
                    cellRange.Text = ChooseRow(column, semester, subject);
                }

                cellRange = table.Cell(row, 9).Range;
                cellRange.Text = ChooseRow(9, semester, subject);

                row++;
            }
        }
    }
}
