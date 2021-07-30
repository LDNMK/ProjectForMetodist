using System.Collections.Generic;
//Пільги
namespace Fait.DAL
{
    public partial class Amend
    {
        public Amend()
        {
            StudentInfos = new HashSet<StudentInfo>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}
