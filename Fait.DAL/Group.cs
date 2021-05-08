using System;
using System.Collections.Generic;

#nullable disable
//Группы
namespace Fait.DAL
{
    public partial class Group
    {
        public Group()
        {
            ActualGroups = new HashSet<ActualGroup>();
        }

        public int Id { get; set; }
        //Ссылка на план
        public int? PlanId { get; set; }
        public int GroupName { get; set; }
        //Актуальна ли группа, если 1 то в ней сейчас учаться, 0 значит уже нет
        public bool Actual { get; set; }
        public int GroupYear { get; set; }

        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<ActualGroup> ActualGroups { get; set; }
    }
}
