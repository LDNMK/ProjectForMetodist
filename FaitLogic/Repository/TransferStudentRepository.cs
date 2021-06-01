﻿using Fait.DAL;
using Fait.DAL.NotMapped;
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

        public List<GroupNameWithId> GetGroupsNames(IEnumerable<int> groupIds)
        {
            return dbContext.Groups
                .Where(x => groupIds.Contains(x.Id))
                .Select(x => 
                    new GroupNameWithId 
                    { 
                        GroupId = x.Id, 
                        GroupName = $"{x.GroupName.NameOfGroup}-{x.GroupNumber}"
                    })
                .ToList();
        }

        public GroupId GetNextGroupOfStudent(int groupId)
        {
            return dbContext.GroupIds.FromSqlRaw("EXEC return_next_group_id_for_student @group_id", new SqlParameter("@group_id", groupId)).AsEnumerable().FirstOrDefault();
        }
    }
}
