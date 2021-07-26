using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Student
    {
        public Student()
        {
            GroupStudents = new HashSet<GroupStudent>();
            Marks = new HashSet<Mark>();
            StudentTransferHistories = new HashSet<StudentTransferHistory>();
        }

        public int Id { get; set; }
        public int? SpecialityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int StudentStateId { get; set; }

        public virtual Speciality Speciality { get; set; }
        public virtual StudentState StudentState { get; set; }
        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<StudentTransferHistory> StudentTransferHistories { get; set; }
    }
}
