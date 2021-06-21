using Fait.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Fait.DAL.Repository
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

        public YearPlan GetYearPlanByGroup(int groupId)
        {
            return dbContext.Groups
                .Where(x => x.Id == groupId)
                .Select(x => x.Plan)
                .FirstOrDefault();
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
