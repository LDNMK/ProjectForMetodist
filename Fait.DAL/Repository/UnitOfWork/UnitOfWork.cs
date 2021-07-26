using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fait.DAL.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FAITContext dbContext;

        private IGroupStudentRepository groupStudentRepository;
        private IGroupRepository groupRepository;
        private IGroupPrefixRepository groupPrefixRepository;
        private IStudentRepository studentRepository;
        private ISubjectRepository subjectRepository;
        private IYearPlanRepository yearPlanRepository;
        private IStudentInfoRepository studentInfoRepository;
        private ISubjectSemesterRepository subjectSemesterRepository;
        private IProgressRepository progressRepository;
        private ISpecialityRepository specialityRepository;
        private IYearPlanGroupsRepository yearPlanGroupsRepository;
        private IStudentTransferHistoryRepository studentTransferHistoryRepository;

        public UnitOfWork(FAITContext context)
        {
            dbContext = context;
        }

        public IGroupStudentRepository GroupStudentRepository
        {
            get
            {
                if (this.groupStudentRepository == null)
                {
                    this.groupStudentRepository = new GroupStudentRepository(dbContext);
                }
                return groupStudentRepository;
            }
        } 
        public IGroupRepository GroupRepository 
        {
            get
            {
                if (this.groupRepository == null)
                {
                    this.groupRepository = new GroupRepository(dbContext);
                }
                return groupRepository;
            }
        }
        public IGroupPrefixRepository GroupPrefixRepository 
        {
            get
            {
                if (this.groupPrefixRepository == null)
                {
                    this.groupPrefixRepository = new GroupPrefixRepository(dbContext);
                }
                return groupPrefixRepository;
            }
        }
        public IStudentRepository StudentRepository 
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(dbContext);
                }
                return studentRepository;
            }
        }
        public ISubjectRepository SubjectRepository 
        {
            get
            {
                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new SubjectRepository(dbContext);
                }
                return subjectRepository;
            }
        }
        public IYearPlanRepository YearPlanRepository 
        {
            get
            {
                if (this.yearPlanRepository == null)
                {
                    this.yearPlanRepository = new YearPlanRepository(dbContext);
                }
                return yearPlanRepository;
            }
        }
        public IStudentInfoRepository StudentInfoRepository 
        {
            get
            {
                if (this.studentInfoRepository == null)
                {
                    this.studentInfoRepository = new StudentInfoRepository(dbContext);
                }
                return studentInfoRepository;
            }
        }
        public ISubjectSemesterRepository SubjectSemesterRepository 
        {
            get
            {
                if (this.subjectSemesterRepository == null)
                {
                    this.subjectSemesterRepository = new SubjectSemesterRepository(dbContext);
                }
                return subjectSemesterRepository;
            }
        }
        public IProgressRepository  ProgressRepository 
        {
            get
            {
                if (this.progressRepository == null)
                {
                    this.progressRepository = new ProgressRepository(dbContext);
                }
                return progressRepository;
            }
        }
        public ISpecialityRepository SpecialityRepository 
        {
            get
            {
                if (this.specialityRepository == null)
                {
                    this.specialityRepository = new SpecialityRepository(dbContext);
                }
                return specialityRepository;
            }
        }
        public IYearPlanGroupsRepository YearPlanGroupsRepository
        {
            get
            {
                if (this.yearPlanGroupsRepository == null)
                {
                    this.yearPlanGroupsRepository = new YearPlanGroupsRepository(dbContext);
                }
                return yearPlanGroupsRepository;
            }
        }

        public IStudentTransferHistoryRepository StudentTransferHistoryRepository
        {
            get
            {
                if (this.studentTransferHistoryRepository == null)
                {
                    this.studentTransferHistoryRepository = new StudentTransferHistoryRepository(dbContext);
                }
                return studentTransferHistoryRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            dbContext.Database.CommitTransaction();
        }

        public void RevertTransaction()
        {
            dbContext.Database.RollbackTransaction();
        }
    }
}
