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

        private readonly Dictionary<string, IRepository.IRepository> repositories;
        public UnitOfWork(
            FAITContext context,
            IActualGroupRepository actualGroupRepository,
            IGroupRepository groupRepository,
            IGroupPrefixRepository groupPrefixRepository,
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository,
            IYearPlanRepository yearPlanRepository,
            IStudentInfoRepository studentInfoRepository,
            ISubjectSemesterRepository subjectSemesterRepository)
        {
            dbContext = context;
            repositories = new Dictionary<string, IRepository.IRepository>();

            ActualGroupRepository = actualGroupRepository;
            GroupRepository = groupRepository;
            GroupPrefixRepository = groupPrefixRepository;
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
            YearPlanRepository = yearPlanRepository;
            StudentInfoRepository = studentInfoRepository;
            SubjectSemesterRepository = subjectSemesterRepository;
        }

        public IActualGroupRepository ActualGroupRepository { get; set; } 
        public IGroupRepository GroupRepository { get; set; }
        public IGroupPrefixRepository GroupPrefixRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }
        public ISubjectRepository SubjectRepository { get; set; }
        public IYearPlanRepository YearPlanRepository { get; set; }
        public IStudentInfoRepository StudentInfoRepository { get; set; }
        public ISubjectSemesterRepository SubjectSemesterRepository { get; set; }

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

        public void Register(IRepository.IRepository repository)
        {
            repositories.Add(repository.GetType().Name, repository);
        }
    }
}
