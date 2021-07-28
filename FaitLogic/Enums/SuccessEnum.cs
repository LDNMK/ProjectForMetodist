using System.ComponentModel;

namespace FaitLogic.Enums
{
    public enum SuccessEnum
    {
        [Description("Група {0} успішно створена")]
        GroupCreated,

        [Description("Звіт про студента успішно створений")]
        ReportCreated,

        [Description("Навчальний план успішно створений")]
        YearPlanCreated,

        [Description("Навчальний план успішно оновлений")]
        YearPlanUpdated
    }
}
