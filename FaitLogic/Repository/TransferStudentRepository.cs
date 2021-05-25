using Fait.DAL;
using FaitLogic.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaitLogic.Repository
{
    public class TransferStudentRepository
    {
        private readonly FAIT4Context dbContext;

        public TransferStudentRepository(FAIT4Context context)
        {
            dbContext = context;
        }

        public List<ICollection<Group>> GetGroups(int course, int year)
        {
            return dbContext.YearPlans
                .Where(x => x.PlanYear == year && x.Course == course)
                .Select(x=>x.Groups)
                .ToList();
        }

        public List<GroupWithIdDTO> GetGroupsNames(IEnumerable<int> groupIds)
        {
            return dbContext.Groups
                .Where(x => groupIds.Contains(x.Id))
                .Select(x => 
                    new GroupWithIdDTO 
                    { 
                        GroupId = x.Id, 
                        GroupName = x.GroupName.NameOfGroup
                    })
                .ToList();
        }

        public void TransferStudentToNextGroup(int studentId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@studentId", studentId)
            };

            dbContext.Database.ExecuteSqlRaw("EXEC transfer_student_to_next_group (@student)", parameters);
        }
    }
}
