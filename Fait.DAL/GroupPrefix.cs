using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class GroupPrefix
    {
        public GroupPrefix()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
