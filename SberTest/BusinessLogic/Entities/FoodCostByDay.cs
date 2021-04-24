namespace BusinessLogic.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FoodCostByDay
    {
        [Key]
        public int Id { get; set; }

        public decimal Count { get; set; }

        public DateTime StartAppointmentDateTime { get; set; }

        public DateTime FinishAppointmentDateTime { get; set; }
    }
}
