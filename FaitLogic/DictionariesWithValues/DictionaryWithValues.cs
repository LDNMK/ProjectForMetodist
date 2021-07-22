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

        public static Dictionary<int, string> ExperienceCompetition { get; set; } = new Dictionary<int, string>();

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
        }
    }

    static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            var curtureInfo = new CultureInfo("ru-RU");
            return curtureInfo.DateTimeFormat.GetMonthName(dateTime.Month);
        }
    }
}
