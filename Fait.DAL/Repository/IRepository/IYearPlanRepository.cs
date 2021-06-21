using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IYearPlanRepository
    {
        List<YearPlan> GetListOfYearPlans(int course);

        int AddYearPlan(YearPlan yearPlan);

        YearPlan FindYearPlan(int yearPlanId);

        YearPlan GetYearPlanByGroup(int groupId);
    }
}
