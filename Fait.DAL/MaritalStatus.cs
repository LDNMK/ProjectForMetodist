using System.Collections.Generic;

//Семейный статус
namespace Fait.DAL
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public byte Id { get; set; }
        public string MaritalStatusName { get; set; }

        //  1 нет информации, 2 женат, 3 не женат

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}
