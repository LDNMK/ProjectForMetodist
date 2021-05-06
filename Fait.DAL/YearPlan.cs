using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class YearPlan
    {
        public YearPlan()
        {
            Groups = new HashSet<Group>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string PlanName { get; set; }
        public int PlanYear { get; set; }
        public byte Course { get; set; }
        public bool Actual { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
