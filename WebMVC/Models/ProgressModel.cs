using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProgressModel
    {
        public ICollection<ProgressSubjectModel> Subjects { get; set; }

        public ICollection<ProgressStudentModel> GroupId { get; set; }
    }

    public class ProgressSubjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProgressStudentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubjectStudentMarkModel> Subjects { get; set; }
    }

    public class SubjectStudentMarkModel
    {
        public int Id { get; set; }

        public int? Mark { get; set; }

        public int? TaskMark { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
