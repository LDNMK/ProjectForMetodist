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
        public string PlanName { get; set; }//название
        public int PlanYear { get; set; }//год
        public byte Course { get; set; }//курс
        public bool Actual { get; set; }//актуальность

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
