using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Group
    {
        public Group()
        {
            GroupStudents = new HashSet<GroupStudent>();
            YearPlanGroups = new HashSet<YearPlanGroup>();
        }

        public int Id { get; set; }
        public int GroupNumber { get; set; }
        public int GroupPrefixId { get; set; }
        public bool Actual { get; set; }
        public int Course { get; set; }

        public virtual GroupPrefix GroupPrefix { get; set; }
        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
        public virtual ICollection<YearPlanGroup> YearPlanGroups { get; set; }
    }
}
