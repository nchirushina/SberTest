namespace BusinessLogic.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<EmployeersWorkDays> Timesheet { get; set; }
    }
}
