using System.Collections.Generic;

namespace Fait.DAL
{
    public partial class Ammende
    {
        public Ammende()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public byte Id { get; set; }
        public string AmmendType { get; set; }

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}
