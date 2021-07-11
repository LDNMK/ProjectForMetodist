using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IYearPlanRepository
    {
        List<YearPlan> GetListOfYearPlans(int course);

        void AddYearPlan(YearPlan yearPlan);

        YearPlan FindYearPlan(int yearPlanId);

        YearPlan GetYearPlanByGroup(int groupId, int year);

        int? GetYearPlanIdByGroup(int groupId, int year);

        int GetLastYearPlanId();
    }
}
