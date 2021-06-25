using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;

namespace Fait.DAL.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IActualGroupRepository ActualGroupRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IGroupPrefixRepository GroupPrefixRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public IYearPlanRepository YearPlanRepository { get; }
        public IStudentInfoRepository StudentInfoRepository { get; }
        public ISubjectSemesterRepository SubjectSemesterRepository { get; }
        public IProgressRepository ProgressRepository { get; }

        void Save();
    }
}
