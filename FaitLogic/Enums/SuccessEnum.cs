using System.ComponentModel;

namespace FaitLogic.Enums
{
    public enum SuccessEnum
    {
        [Description("Група {0} створена")]
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
