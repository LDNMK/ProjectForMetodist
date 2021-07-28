using System.ComponentModel;

namespace FaitLogic.Enums
{
    public enum WarningEnum
    {
        [Description("За вказаними критеріями не було знайдено жодної групи")]
        GroupsNotFound,

        [Description("За вказаними критеріями не було знайдено жодного студента")]
        StudentsNotFound,

        [Description("За вказаними критеріями не було знайдено жодного навчального плану")]
        YearPlanNotFound
    }
}
