using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository
{
    public class YearPlanGroupsRepository : Repository<YearPlanGroup>, IYearPlanGroupsRepository
    {
        public YearPlanGroupsRepository(FAITContext context)
            : base (context)
        {
        }

        public void AddYearPlanGroups(YearPlanGroup yearPlanGroup)
        {
            base.Add(yearPlanGroup);
        }
    }
}
