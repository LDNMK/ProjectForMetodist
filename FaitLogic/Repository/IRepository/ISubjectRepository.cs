using Fait.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Repository.IRepository
{
    public interface ISubjectRepository
    {
        List<SubjectInfo> FindSubjectsInfo(int yearPlanId);

        List<Subject> FindSubjects(int subjectId);

        int? AddSubjectInfo(SubjectInfo subjectInfo);

        void AddSubject(Subject subject);
    }
}
