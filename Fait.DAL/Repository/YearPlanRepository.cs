using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fait.DAL.Repository
{
    public class YearPlanRepository : Repository<YearPlan>, IYearPlanRepository
    {
        public YearPlanRepository(FAITContext context)
            : base(context)
        {
        }

        public YearPlan FindYearPlan(int yearPlanId)
        {
            return FindById(yearPlanId);
            //return dbContext.YearPlans
            //    .Where(x => x.Id == yearPlanId)
            //    .Single();
        }

        //TODO: Change maybe
        public List<YearPlan> GetListOfYearPlans(int course)
        {
            return dbContext.YearPlans
                //.Where(x => x.Course == course)
                .ToList();
        }

        public YearPlan GetYearPlanByGroup(int groupId, int year)
        {
            return dbContext.YearPlanGroups
                .Where(x => x.GroupId == groupId && x.YearPlan.Year == year)
                .Select(x => x.YearPlan)
                .FirstOrDefault();
        }

        public int? GetYearPlanIdByGroup(int groupId, int year)
        {
            int? planId = dbContext.YearPlanGroups
                .Where(x =>
                    x.GroupId == groupId &&
                    x.YearPlan.Year == year)
                .Select(x => x.YearPlanId)
                .FirstOrDefault();

            return planId == 0 ? null : planId;
        }

        public void AddYearPlan(YearPlan yearPlan)
        {
            base.Add(yearPlan);
            //dbContext.YearPlans.Add(yearPlan);
            //dbContext.SaveChanges();
        }

        public int GetLastYearPlanId()
        {
            return dbContext.YearPlans
                .OrderBy(x => x.Id)
                .LastOrDefault().Id;
        }
    }
}
