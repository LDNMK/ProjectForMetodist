using System.Collections.Generic;
//Пільги
namespace Fait.DAL
{
    public partial class Ammende
    {
        public Ammende()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public byte Id { get; set; }            //айди льготы
        public string AmmendType { get; set; }  //описание льготы
          /*  на условиях полной компенсации:
	        --2 Державний кредит
	        --3 фізична
	        --4 юридична
	        --1 нет информации\
          */

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}
