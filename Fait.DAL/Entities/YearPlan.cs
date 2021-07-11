using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class YearPlan
    {
        public YearPlan()
        {
            Subjects = new HashSet<Subject>();
            YearPlanGroups = new HashSet<YearPlanGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<YearPlanGroup> YearPlanGroups { get; set; }
    }
}
