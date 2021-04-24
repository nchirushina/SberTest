namespace BusinessLogic.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeersWorkDays
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [ForeignKey("WorkDay")]
        public int WorkDayId { get; set; }

        public WorkDay WorkDay { get; set; }
    }
}
