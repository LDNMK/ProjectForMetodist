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
        public int? PlanId { get; set; }//учебнвй план
        public int GroupNumber { get; set; }//номер группы
        public byte? GroupName { get; set; }//код группы
        public bool Actual { get; set; }//актуальна ли группа
        public int GroupYear { get; set; }//год

        public virtual GroupName GroupNameNavigation { get; set; }
        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<ActualGroup> ActualGroups { get; set; }
    }
}
