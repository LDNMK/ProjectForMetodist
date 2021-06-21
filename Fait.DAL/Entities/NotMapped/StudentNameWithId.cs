using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fait.DAL.NotMapped
{
    [NotMapped]
    public class StudentNameWithId
    {
        public int StudentId { get; set; }

        public string StudentName {get; set; }
    }
}
