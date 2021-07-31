using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentTransferHistory
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int StateId { get; set; }

        public byte FromCourse { get; set; }

        public byte ToCourse { get; set; }

        public DateTime OperationDate { get; set; }

        public string OrderNumber { get; set; }

        public DateTime? OrderDate { get; set; }

        public string Content { get; set; }

        public virtual StudentState State { get; set; }
        public virtual Student Student { get; set; }
    }
}
