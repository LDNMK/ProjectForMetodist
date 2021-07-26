using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;

namespace Fait.DAL.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGroupStudentRepository GroupStudentRepository { get; }
        IGroupRepository GroupRepository { get; }
        IGroupPrefixRepository GroupPrefixRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IYearPlanRepository YearPlanRepository { get; }
        IStudentInfoRepository StudentInfoRepository { get; }
        ISubjectSemesterRepository SubjectSemesterRepository { get; }
        IProgressRepository ProgressRepository { get; }
        ISpecialityRepository SpecialityRepository { get; }
        IYearPlanGroupsRepository YearPlanGroupsRepository { get; }
        IStudentTransferHistoryRepository StudentTransferHistoryRepository { get; }

        void Save();

        void BeginTransaction();

        void CommitTransaction();

        void RevertTransaction();

    }
}
