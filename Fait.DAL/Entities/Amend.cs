using System.Collections.Generic;
//Пільги
namespace Fait.DAL
{
    public partial class Amend
    {
        public Amend()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public int Id { get; set; }            // Id льготы
        public string Name { get; set; }   // Описание льготы
          /*
           * На условиях полной компенсации:
           * 1 Нет информации
           * 2 Державний кредит
           * 3 Фізична
           * 4 Юридична
          */

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}
