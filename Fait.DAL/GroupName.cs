using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.Dal
{
    public partial class GroupName
    {
        public GroupName()
        {
            Groups = new HashSet<Group>();
        }

        public byte Id { get; set; }
        public string GroupName1 { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
