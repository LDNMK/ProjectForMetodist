namespace Fait.DAL
{// Таблица, где показывает какие студенты в каких группах
    public partial class ActualGroup
    {
        //Поля
        public int Id { get; set; }//Id сущности
        public int? GroupId { get; set; }//Id групы в которой студент
        public int? StudentId { get; set; }//Id студента
        //Сущности отвечающие за внешние ключи
        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
