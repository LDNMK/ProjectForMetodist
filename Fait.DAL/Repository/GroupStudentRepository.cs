using Fait.DAL.Entities.NotMapped;
using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fait.DAL.Repository
{
    public class GroupStudentRepository : Repository<GroupStudent>, IGroupStudentRepository
    {
        public GroupStudentRepository(FAITContext context)
            : base(context)
        {
        }

        public void AddGroupStudent(GroupStudent groupStudent)
        {
            base.Add(groupStudent);
        }

        public void AddGroupStudents(ICollection<GroupStudent> groupStudents)
        {
            base.AddRange(groupStudents);
        }

        public GroupStudent FindStudentActualGroup(int studentId)
        {
            return base.Find(x => 
                x.StudentId == studentId 
                && x.Group.Actual == true)
                .OrderByDescending(x => x.GroupYear)
                .FirstOrDefault();
            //return dbContext.ActualGroups
            //    .Where(x => x.StudentId == studentId && x.Group.Actual == true)
            //    .SingleOrDefault();
        }

        public IEnumerable<GroupWithYear> GetStudentGroups(int studentId)
        {
            return Find(x => x.StudentId == studentId)
                .Select(
                    x => new GroupWithYear
                    {
                        GroupId = x.GroupId,
                        Year = x.GroupYear,
                        Course = x.Group.Course
                    });
        }

        public void UpdateActualGroup(GroupStudent group)
        {
            base.Update(group);
        }
    }
}
