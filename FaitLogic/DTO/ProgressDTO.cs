using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class ProgressDTO
    {
        public ICollection<ProgressSubjectDTO> Subjects { get; set; }

        public ICollection<ProgressStudentDTO> Students { get; set; }
    }

    public class ProgressSubjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCourseWorkExist { get; set; }
    }

    public class ProgressStudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubjectStudentMarkDTO> Subjects { get; set; }
    }

    public class SubjectStudentMarkDTO
    {
        public int Id { get; set; }

        public int? Mark { get; set; }

        public int? TaskMark { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
