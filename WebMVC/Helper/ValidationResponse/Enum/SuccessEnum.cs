using System.ComponentModel;

namespace WebAPI.Helper.ValidationResponse.Enum
{
    public enum SuccessEnum
    {
        [Description("Група створена")]
        GroupCreated,

        [Description("Звіт про студента створений")]
        ReportCreated,

        [Description("Навчальний план створений")]
        YearPlanCreated,

        [Description("Навчальний план оновлений")]
        YearPlanUpdated,

        [Description("Успішність оновлена")]
        ProgressUpdated,

        [Description("Карта студента оновлена")]
        StudentCardUpdated,

        [Description("Статус студентів змінений")]
        TransferStudentsUpdated
    }
}
