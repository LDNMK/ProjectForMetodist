using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Group
    {
        public Group()
        {
            ActualGroups = new HashSet<ActualGroup>();
        }

        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int GroupName { get; set; }
        public bool Actual { get; set; }

        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<ActualGroup> ActualGroups { get; set; }
    }
}
