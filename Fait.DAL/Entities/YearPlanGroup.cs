using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class YearPlanGroup
    {
        public int YearPlanId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual YearPlan YearPlan { get; set; }
    }
}
