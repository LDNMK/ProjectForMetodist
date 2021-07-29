using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class TransferStudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int StateId { get; set; }

        public int? GroupId { get; set; }

        public bool IsActive { get; set; }
    }
}
