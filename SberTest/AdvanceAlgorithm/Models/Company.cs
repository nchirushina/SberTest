namespace AdvanceAlgorithm.Models
{
    using System;

    public class Company
    {
        public int Id { get; set; }

        // Original field: "AdvPrc"
        public int AdvancePercent { get; set; }

        // Original field: "MinWDay"
        public int MinimalWorkedDayCount { get; set; }

        // Original field: UseAdvDay
        public bool UseAdvanceDay { get; set; }

        // Original field: DE
        public DateTime AdvanceDay { get; set; }
    }
}
