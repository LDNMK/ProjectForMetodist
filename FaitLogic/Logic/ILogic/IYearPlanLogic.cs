using FaitLogic.DTO;
using System.Collections.Generic;

namespace FaitLogic.Logic.ILogic
{
    public interface IYearPlanLogic
    {
        void AddYearPlan(YearPlanDTO yearPlanInfo);
        int? GetYearPlanIdByGroup(int groupId, int year);
        ICollection<YearPlanNameWithIdDTO> GetYearPlans(int course);
        YearPlanDTO ShowYearPlan(int yearPlanId);
        void UpdateYearPlan(YearPlanDTO yearPlanInfo, int yearPlanId);
    }
}