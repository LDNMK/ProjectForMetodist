using System.ComponentModel;

namespace FaitLogic.Enums
{
    public enum ErrorEnum
    {
        // Students
        [Description("Дані про студента вказані некоректно або вони вже використовуються")]
        StudentDbUpdateFailed,

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
        UpdateYearPlanFailed
    }
}
