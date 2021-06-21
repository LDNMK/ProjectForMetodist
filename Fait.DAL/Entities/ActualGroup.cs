namespace Fait.DAL
{       // Таблица, где показывается, какие студенты в каких группах
    public partial class ActualGroup
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }       // Id групы в которой студент
        public int? StudentId { get; set; }     // Id студента

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
