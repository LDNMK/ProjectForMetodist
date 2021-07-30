using Fait.DAL.Entities.NotMapped;
using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IGroupStudentRepository
    {
        GroupStudent FindStudentActualGroup(int studentId);

        void AddGroupStudent(GroupStudent groupStudent);

        IEnumerable<GroupWithYear> GetStudentGroups(int studentId);
    }
}
