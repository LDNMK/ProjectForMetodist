using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class SubjectInfo
    {
        public SubjectInfo()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public int? PlanId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Ects { get; set; }
        public string Faculty { get; set; }

        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
