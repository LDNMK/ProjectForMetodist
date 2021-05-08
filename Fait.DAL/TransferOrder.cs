using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class TransferOrder
    {
        public int OrderId { get; set; }
        public int? StudentId { get; set; }//студент
        public byte Course { get; set; }//курс
        public DateTime OrderDate { get; set; }//дата
        public string Content { get; set; }//контент

        public virtual Student Student { get; set; }
    }
}
