using Fait.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Repository.IRepository
{
    public interface ISubjectRepository
    {
        List<Subject> FindSubjects(int yearPlanId);

        List<SubjectSemester> FindSubjectSemesters(int subjectId);

        int AddSubject(Subject subjectInfo);

        void AddSubjectSemester(SubjectSemester subject);
    }
}
