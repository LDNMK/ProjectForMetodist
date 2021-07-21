﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class StudentTransferHistoryDTO
    {
        public int Id { get; set; }

        //public int StudentId { get; set; }

        //public int StateId { get; set; }

        //public byte FromCourse { get; set; }

        public byte ToCourse { get; set; }

        //public DateTime OperationDate { get; set; }

        public string OrderNumber { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}
