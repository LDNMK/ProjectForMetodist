namespace FaitLogic.DTO
{
    public class StudentCardDTO
    {
        public int Course { get; set; }
        public int GroupId { get; set; }
        //public string LevelOfDegree { get; set; }
        public string Speciality { get; set; }
        public string Specialization { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public string BirthPlace { get; set; }//Місце народження
        public string Immenseness { get; set; } //Громадянство 
        public byte? MaritalStatusId { get; set; }//Сімейний стан
        public string Registration { get; set; }//Місце проживання\регістрації
        public string Exemption { get; set; }//Наявність пільг при втсупі
        public byte? ExpirienceCompetitionId { get; set; }
        public string TransferFrom { get; set; }
        public string TransferDirection { get; set; }
        public string CompetitionConditions { get; set; }
        public string OutOfCompetitionInfo { get; set; }
        public int? AmendId { get; set; }
        public int OrderNumber { get; set; } //Номер наказу 
        public string OrderDate { get; set; } //Дата наказу
        public int EmploymentNumber { get; set; }// код рабочей кнжики
        public string EmploymentAuthority { get; set; }// кто выдал рабочую книжку
        public string EmploymentGivenDate { get; set; } //дата ее выдачи
        public string RegistrOrPassportNumber { get; set; }// код регистарции или серия и номер паспорта
        public byte StudentStateId { get; set; }// состояние студента
    }
}
