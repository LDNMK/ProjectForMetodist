using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class TransferOrder
    {
        public int OrderId { get; set; }
        public int? StudentId { get; set; }
        public byte Course { get; set; }
        public DateTime OrderDate { get; set; }
        public string Content { get; set; }

        public virtual Student Student { get; set; }
    }
}
