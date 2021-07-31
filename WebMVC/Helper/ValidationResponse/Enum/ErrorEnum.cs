using System.ComponentModel;

namespace  WebAPI.Helper.ValidationResponse.Enum
{
    public enum ErrorEnum
    {
        // Students
        [Description("Дані про студента вказані некоректно або вони вже використовуються")]
        StudentCardUpdateFailed,

        [Description("Виникла помилка під час збереження інформації про студента")]
        StudentCardSaveFailed,

        // Year plans
        [Description("Такого навчального плану немає")]
        YearPlanNotExist,

        // Groups
        [Description("Така група вже існує")]
        GroupAlreadyExist,

        // Reports
        [Description("Виникла помилка під час створення звіту для студента")]
        CreateReportFailed,

        // YearPlans
        [Description("Виникла помилка під час створення навчального плану")]
        CreateYearPlanFailed,

        [Description("Виникла помилка під час оновлення навчального плану")]
        YearPlanUpdateFailed,

        // Progress
        [Description("Виникла помилка під час оновлення успішності")]
        ProgressUpdateFailed,

        [Description("Виникла помилка під час завантаження успішності")]
        ProgressLoadFailed,

        [Description("Виникла помилка під час зміни статусу студентам")]
        TransferStudentsUpdateFailed

    }
}
