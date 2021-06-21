using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface ISubjectRepository
    {
        List<Subject> FindSubjects(int yearPlanId);

        List<SubjectSemester> FindSubjectSemesters(int subjectId);

        int AddSubject(Subject subjectInfo);

        void AddSubjectSemester(SubjectSemester subject);
    }
}
