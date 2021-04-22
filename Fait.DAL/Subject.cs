using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public int? PlanId { get; set; }
        public string SubName { get; set; }
        public int SubHours { get; set; }
        public int Ects { get; set; }
        public bool Monitoring { get; set; }
        public bool Task { get; set; }
        public byte Semester { get; set; }

        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
