using AutoMapper;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DictionariesWithValues;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic.ILogic;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FaitLogic.Logic
{
    public class ReportLogic : IReportLogic
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
            studentInfo.Add("Degree", DictionaryWithValues.Degrees[studentInfoDto.DegreeId]);
            studentInfo.Add("Speciality", DictionaryWithValues.Specialities[studentInfoDto.SpecialityId]);
            studentInfo.Add("Name", string.Format("{0} {1} {2}", studentInfoDto.LastName, studentInfoDto.FirstName, studentInfoDto.Patronymic));
            studentInfo.Add("Birthday", studentInfoDto.Birthdate.ToString("dd.MM.yyyy"));
            studentInfo.Add("BirthPlace", studentInfoDto.BirthPlace);
            studentInfo.Add("Citizenship", studentInfoDto.Citizenship);
            studentInfo.Add("MaritalStatus", DictionaryWithValues.MaritalStatus[studentInfoDto.MaritalStatusId]);
            studentInfo.Add("GraduatedSchoolName", studentInfoDto.GraduatedSchoolName);
            studentInfo.Add("GraduatedYear", studentInfoDto.GraduatedYear.ToString());
            studentInfo.Add("Registration", studentInfoDto.Registration);
            studentInfo.Add("Exemption", studentInfoDto.Exemption);
            studentInfo.Add("ExpirienceCompetition", DictionaryWithValues.ExperienceCompetition[studentInfoDto.ExperienceCompetitionId]);
            studentInfo.Add("TransferFrom", studentInfoDto.TransferFrom);
            studentInfo.Add("TransferDirection", studentInfoDto.TransferDirection);
            studentInfo.Add("CompetitionConditions", studentInfoDto.CompetitionConditions);
            studentInfo.Add("OutOfCompetitionInfo", studentInfoDto.OutOfCompetitionInfo);
            studentInfo.Add("Amend", DictionaryWithValues.Ammends[studentInfoDto.AmendsId]);
            studentInfo.Add("OrderNumber", studentInfoDto.OrderNumber);
            studentInfo.Add("OrderDate", string.Format("\"{0}\" {1} {2} року", orderDate.Day.ToString().PadLeft(2, '0'), orderDate.ToMonthName(), orderDate.Year));
            studentInfo.Add("Employment",
                string.Format("{0} {1} {2}",
                    studentInfoDto.EmploymentNumber.ToString(),
                    studentInfoDto.EmploymentGivenDate.GetValueOrDefault().ToString("dd.MM.yyyy"),
                    studentInfoDto.EmploymentAuthority));
            studentInfo.Add("RegistrOrPassportNumber", studentInfoDto.RegistrOrPassportNumber);

            CreateDocument(studentInfo, studentProgresses, studentInfoDto.TransferHistory);
        }

        private void CreateDocument(Dictionary<string, string> studentInfo, ICollection<StudentProgressDTO> studentProgresses, ICollection<StudentTransferHistoryDTO> studentTransferHistories)
        {
            var application = new Application();
            Document document = null;

            object missingObj = Missing.Value;
            object falseObj = false;

            object documentPath = Path.GetFullPath("Student.doc");
            try
            {
                document = application.Documents.Add(ref documentPath, ref missingObj, ref missingObj, ref missingObj);
            }
            catch (Exception e)
            {
                document?.Close(ref falseObj, ref missingObj, ref missingObj);
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
                bookmarkRange.Font.Bold = 0;
                bookmarkRange.Underline = WdUnderline.wdUnderlineSingle;
            }

            Table table = document.Tables[1];
            var row = 2;
            foreach (var studentTransferHistory in studentTransferHistories)
            {
                Microsoft.Office.Interop.Word.Range cellRange;
                for (int column = 1; column <= 3; column++)
                {
                    cellRange = table.Cell(row, column).Range;
                    cellRange.Text = GetInfoForTransferRow(column, studentTransferHistory);
                    cellRange.Font.Bold = 0;
                }
                row++;
            }

            table = document.Tables[2];

            var rows = new Dictionary<int, int[]>()
            {
                //key - course, value - {AutumnRow, SpringRow}
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

                FillProgressTable(studentProgress, table, courseSemesters[0], courseSemesters[1]); // 0 - Autumn, 1 - Spring
            }

            application.Visible = true;

            application.Quit(ref missingObj, ref missingObj, ref missingObj);
        }

        private static string GetInfoForProgressRow(int column, int semester, StudentSubjectDTO subject)
        {
            var subjectSemester = subject.SubjectSemesters.Single(x => x.SemesterId == semester);
            var ectsMark = GetECTSMark(subjectSemester.Mark);
            return column switch
            {
                3 => subject.Name,
                4 => subject.Hours.ToString(),
                5 => subject.Ects.ToString(),
                6 => DictionaryWithValues.Mark[ectsMark],
                7 => subjectSemester.Mark.ToString(),
                8 => ectsMark,
                9 => subjectSemester.ModifiedOn.ToString("dd.MM.yyyy"),
                _ => throw new ArgumentException()
            };
        }

        private static string GetInfoForTransferRow(int column, StudentTransferHistoryDTO studentTransferHistory)
        {
            return column switch
            {
                1 => studentTransferHistory.ToCourse.ToString(),
                2 => string.Format("{0}  {1}", studentTransferHistory.OrderNumber, studentTransferHistory.OrderDate?.Date.ToString("dd.MM.yyyy")),
                3 => studentTransferHistory.Content,
                _ => throw new ArgumentException()
            };
        }

        private static void FillProgressTable(StudentProgressDTO studentProgress, Table table, int rowAutumn, int rowSpring)
        {
            foreach (var subject in studentProgress.Subjects)
            {
                FillSemester(subject, table, ref rowAutumn, (int)SemesterEnum.Autumn);
                FillSemester(subject, table, ref rowSpring, (int)SemesterEnum.Spring);
            }
        }

        private static string GetECTSMark(int mark)
        {
            if (mark >= 82)
            {
                if (mark >= 90)
                    return "A";

                return "B";
            }

            if (mark >= 64)
            {
                if (mark >= 74)
                    return "C";

                return "D";
            }

            if (mark >= 60)
                return "E";

            if (mark >= 35)
                return "FX";

            return "F";
        }

        private static void FillSemester(StudentSubjectDTO subject, Table table, ref int row, int semester)
        {
            if (subject.SubjectSemesters.Any(x => x.SemesterId == semester))
            {
                Microsoft.Office.Interop.Word.Range cellRange;
                for (int column = 3; column <= 9; column++)
                {
                    cellRange = table.Cell(row, column).Range;
                    cellRange.Text = GetInfoForProgressRow(column, semester, subject);
                    cellRange.Font.Bold = 0;
                    if (column == 6)
                    {
                        cellRange.Font.Size = 10;
                    }
                }

                row++;
            }
        }
    }
}
