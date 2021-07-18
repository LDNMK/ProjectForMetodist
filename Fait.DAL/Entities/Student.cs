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
            StudentTransferOrders = new HashSet<StudentTransferHistory>();
        }

        public int Id { get; set; }
        public int? SpecialityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public byte StudentStateId { get; set; }

        public virtual Speciality Speciality { get; set; }
        public virtual StudentState StudentState { get; set; }
        public virtual StudentsInfo StudentsInfo { get; set; }
        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<StudentTransferHistory> StudentTransferOrders { get; set; }
    }
}
