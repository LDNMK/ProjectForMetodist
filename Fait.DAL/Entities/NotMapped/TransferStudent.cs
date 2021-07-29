using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fait.DAL.Entities.NotMapped
{
    [NotMapped]
    public class TransferStudent
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
