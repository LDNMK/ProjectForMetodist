using System.Collections.Generic;

//Семейный статус
namespace Fait.DAL
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            StudentInfos = new HashSet<StudentInfo>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}
