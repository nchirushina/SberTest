namespace AdvanceAlgorithm.Models
{
    using System;

    public class Employee
    {
        public int Id { get; set; }

        // Original field: "DateBegin"
        public DateTime DateBeginOfWork { get; set; }

        // Original field: "DateEnd"
        public DateTime DateEndOfWork { get; set; }

        public decimal Salary { get; set; }
    }
}
