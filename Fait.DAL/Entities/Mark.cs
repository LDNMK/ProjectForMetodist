using System;
using System.Collections.Generic;

#nullable disable
//таблица оценок
namespace Fait.DAL
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int? SubjectMark { get; set; }
        public int? TaskMark { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Student Student { get; set; }
        public virtual SubjectSemester Subject { get; set; }
    }
}
