using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentsInfo
    {
        public int? Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthPlace { get; set; }
        public string Immenseness { get; set; }
        public byte? MaritalStatus { get; set; }
        public string Registartion { get; set; }
        public string Exemption { get; set; }
        public byte? Competition { get; set; }
        public string FromIns { get; set; }
        public string Direction { get; set; }
        public string Uniq { get; set; }
        public string NoCompetititon { get; set; }
        public byte? Ammends { get; set; }

        public virtual Student IdNavigation { get; set; }
    }
}
