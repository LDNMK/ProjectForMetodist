using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fait.DAL.Repository
{
    public class YearPlanRepository : Repository<YearPlan>, IYearPlanRepository
    {
        //public YearPlanRepository(FAITContext context, IUnitOfWork unitOfWork)
        //    : base(context, unitOfWork)
        //{
        //}

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

        public YearPlan GetYearPlanByGroup(int groupId)
        {
            return dbContext.Groups
                .Where(x => x.Id == groupId)
                .Select(x => x.Plan)
                .FirstOrDefault();
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
