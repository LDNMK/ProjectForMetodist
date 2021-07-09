﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class SubjectSemester
    {
        public SubjectSemester()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        
        public int SubjectId { get; set; }
        
        public byte ControlType { get; set; }
        
        public int IndividualTaskType { get; set; }
        
        public byte Semester { get; set; }

        public virtual Subject Subject { get; set; }
        
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
