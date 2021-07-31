using System.ComponentModel;

namespace WebAPI.Helper.ValidationResponse.Enum
{
    public enum WarningEnum
    {
        [Description("За вказаними критеріями не було знайдено жодної групи")]
        GroupsNotFound,

        [Description("За вказаними критеріями не було знайдено жодного студента")]
        StudentsNotFound,

        [Description("За даним студентом не було знайдено інформацію")]
        StudentNotFound,

        [Description("За вказаними критеріями не було знайдено жодного навчального плану")]
        YearPlanNotFound,

        [Description("За вказаними критеріями було знайдено навчальний план, але він не містить предметів")]
        ProgressSubjectsNotFound,

        [Description("За вказаними критеріями було знайдено навчальний план, але він не містить студентів")]
        ProgressStudentsNotFound,

        [Description("За вказаними критеріями не було знайдено жодної спеціальності")]
        SpecialitiesNotFound,

        [Description("За вказаними критеріями не було знайдено жодного студента для переведення")]
        TransferStudentsNotFound
    }
}
