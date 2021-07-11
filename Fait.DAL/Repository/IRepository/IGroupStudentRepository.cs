using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IGroupStudentRepository
    {
        void UpdateActualGroup(GroupStudent group);

        GroupStudent FindStudentActualGroup(int studentId);

        void AddGroupStudent(GroupStudent groupStudent);

        void AddGroupStudents(ICollection<GroupStudent> groupStudents);
    }
}
