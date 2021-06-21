using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectSemesters = new HashSet<SubjectSemester>();
        }

        public int Id { get; set; }
        public int? PlanId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Ects { get; set; }
        public string Department { get; set; }

        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<SubjectSemester> SubjectSemesters { get; set; }
    }
}
