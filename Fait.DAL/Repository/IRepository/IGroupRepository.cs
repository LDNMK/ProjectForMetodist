using Fait.DAL.Entities.NotMapped;
using Fait.DAL.NotMapped;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fait.DAL.Repository.IRepository
{
    public interface IGroupRepository
    {
        void AddGroup(Group group);

        bool CheckIfGroupExist(int groupNumber, int? groupNameId);

        Group FindExistingGroup(int groupId);

        //ICollection<Group> FindGroupsByYearPlan(int yearPlanId);

        ICollection<GroupNameWithId> GetGroupNames(IEnumerable<int> groupIds);

        //int GetNextGroupOfStudent(int groupId);

        void UpdateGroup(Group group);

        ICollection<Group> GetGroups(int course, int year);

        ICollection<Group> GetGroups(int course);

        ICollection<int> GetGroupIds(int course, int? year);

        //ICollection<Group> GetDeactivatedGroups();

        Task<ICollection<TransferStudent>> GetStudents(int groupId, int year);

        int GetNextGroupId(int groupId);
    }
}
