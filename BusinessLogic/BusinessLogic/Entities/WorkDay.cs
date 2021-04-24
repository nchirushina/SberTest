namespace BusinessLogic.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BusinessLogic.Enum;

    public class WorkDay
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOfWorkDay { get; set; }

        public EWorkDayStatus WorkDayStatus { get; set; }
    }
}
