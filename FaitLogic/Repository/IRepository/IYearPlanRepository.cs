using Fait.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Repository.IRepository
{
    public interface IYearPlanRepository
    {
        List<YearPlan> GetListOfYearPlans(int course);

        int AddYearPlan(YearPlan yearPlan);

        YearPlan FindYearPlan(int yearPlanId);
    }
}
