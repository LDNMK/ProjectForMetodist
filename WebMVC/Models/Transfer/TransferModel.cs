using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TransferModel
    {
        public short Course { get; set; }

        public string Group { get; set; }

        public int Year { get; set; }

        public ICollection<TransferStudentModel> Students { get; set; }

    }
}
