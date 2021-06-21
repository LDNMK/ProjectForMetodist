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

        public int? PlanId { get; set; }            // Учебный план

        public int GroupNumber { get; set; }        // Номер группы

        public int? GroupPrefixId { get; set; }    // Код группы

        public bool Actual { get; set; }            // Актуальна ли группа

        public int Course { get; set; }             // Курс

        public virtual GroupPrefix GroupPrefix { get; set; }
        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<ActualGroup> ActualGroups { get; set; }
    }
}
