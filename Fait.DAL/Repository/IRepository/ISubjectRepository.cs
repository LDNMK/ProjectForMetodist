using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface ISubjectRepository
    {
        ICollection<Subject> FindSubjects(int yearPlanId);

        void AddSubject(Subject subjectInfo);

        int GetLastSubjectId();
    }
}
