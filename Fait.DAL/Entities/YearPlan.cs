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
        public string Name { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
