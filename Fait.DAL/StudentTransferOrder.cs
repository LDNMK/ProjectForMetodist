using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentTransferOrder
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public byte FromCourse { get; set; }
        public byte ToCourse { get; set; }
        public DateTime OperationDate { get; set; }
        public string Content { get; set; }

        public virtual Student Student { get; set; }
    }
}
