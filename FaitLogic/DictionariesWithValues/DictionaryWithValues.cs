using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FaitLogic.DictionariesWithValues
{
    public static class DictionaryWithValues
    {
        public static Dictionary<int, string> MaritalStatus { get; set; } = new Dictionary<int, string>();
        public static Dictionary<int, string> Degrees { get; set; } = new Dictionary<int, string>();
        public static Dictionary<int, string> Ammends { get; set; } = new Dictionary<int, string>();

        public static Dictionary<int, string> Specialities { get; set; } = new Dictionary<int, string>();

        public static Dictionary<int, string> ExperienceCompetition { get; set; } = new Dictionary<int, string>();

        public static Dictionary<string, string> Mark { get; set; } = new Dictionary<string, string>();

        public static Dictionary<int, string> Months { get; set; } = new Dictionary<int, string>();

        static DictionaryWithValues()
        {
            MaritalStatus.Add(1,"Інформація відстутня");
            MaritalStatus.Add(2, "Одруженний");
            MaritalStatus.Add(3, "Неодруженний");

            Degrees.Add(1, "Бакалавр");
            Degrees.Add(2, "Магістр");

            Ammends.Add(1, "Інформація відстутня");
            Ammends.Add(2, "Державний кредит");
            Ammends.Add(3, "Фізична особа");
            Ammends.Add(4, "Юридична особа");

            ExperienceCompetition.Add(1, "Інформація відсутня");
            ExperienceCompetition.Add(2, "Із стажем");
            ExperienceCompetition.Add(3, "Без стажу");

            Specialities.Add(1, "122 - Комп`ютерні науки");
            Specialities.Add(2, "126 - Інформаційні системи та технології");
            Specialities.Add(3, "121 - Інформаційне програмне забезпечення");

            Mark.Add("A", "відмінно");
            Mark.Add("B", "добре");
            Mark.Add("C", "добре");
            Mark.Add("D", "задовільно");
            Mark.Add("E", "задовільно");
            Mark.Add("FX","незадовільно");
            Mark.Add("F", "незадовільно");

            Months.Add(1, "січня");
            Months.Add(2, "лютого");
            Months.Add(3, "березня");
            Months.Add(4, "квітня");
            Months.Add(5, "травня");
            Months.Add(6, "червня");
            Months.Add(7, "липня");
            Months.Add(8, "серпня");
            Months.Add(9, "вересня");
            Months.Add(10, "жовтня");
            Months.Add(11, "листопада");
            Months.Add(12, "грудня");
        }
    }

    static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return DictionaryWithValues.Months[dateTime.Month];
        }
    }
}
