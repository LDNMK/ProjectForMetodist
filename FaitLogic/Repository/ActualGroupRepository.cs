using Fait.DAL;
using FaitLogic.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Repository
{
    public class ActualGroupRepository : IActualGroupRepository
    {
        private readonly FAIT4Context dbContext;

        public ActualGroupRepository(FAIT4Context context)
        {
            dbContext = context;
        }

        public void AddActualGroup(ActualGroup actualGroup)
        {
            dbContext.ActualGroups.Add(actualGroup);
            dbContext.SaveChanges();
        }

        public void AddActualGroups(ICollection<ActualGroup> actualGroups)
        {
            dbContext.ActualGroups.AddRange(actualGroups);
            dbContext.SaveChanges();
        }

        public ActualGroup FindStudentActualGroup(int studentId)
        {
            return dbContext.ActualGroups
                .Where(x => x.StudentId == studentId && x.Group.Actual == true)
                .SingleOrDefault();
        }

        public void UpdateActualGroup(ActualGroup group)
        {
            dbContext.ActualGroups.Update(group);
            dbContext.SaveChanges();
        }
    }
}
