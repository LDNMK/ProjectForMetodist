using Fait.DAL.Entities.NotMapped;
using Fait.DAL.Repository.IRepository;
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

        public GroupStudent FindStudentActualGroup(int studentId)
        {
            return base.Find(x => 
                x.StudentId == studentId 
                && x.IsActive == true)
                .OrderByDescending(x => x.GroupYear)
                .FirstOrDefault();
        }

        public IEnumerable<GroupWithYear> GetStudentGroups(int studentId)
        {
            return dbContext.GroupStudents.Where(x => x.StudentId == studentId)
                .Select(
                    x => new GroupWithYear
                    {
                        GroupId = x.GroupId,
                        Year = x.GroupYear,
                        Course = x.Group.Course
                    })
                .ToList();
        }
    }
}
