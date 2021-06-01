using System.ComponentModel.DataAnnotations.Schema;

namespace Fait.DAL.NotMapped
{
    [NotMapped]
    public class GroupNameWithId
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }
    }
}
