using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Repository
{
    public class YearPlanRepository : IYearPlanRepository
    {
        private readonly FAITContext dbContext;

        public YearPlanRepository(FAITContext context)
        {
            dbContext = context;
        }

        public YearPlan FindYearPlan(int yearPlanId)
        {
            return dbContext.YearPlans
                .Where(x => x.Id == yearPlanId)
                .Single();
        }

        public List<YearPlan> GetListOfYearPlans(int course)
        {
            return dbContext.YearPlans
                //.Where(x => x.Course == course)
                .ToList();
        }

        public int AddYearPlan(YearPlan yearPlan)
        {
            dbContext.YearPlans.Add(yearPlan);
            dbContext.SaveChanges();

            return dbContext.YearPlans
                .OrderBy(x =>x.Id)
                .LastOrDefault().Id;
        }
    }
}
