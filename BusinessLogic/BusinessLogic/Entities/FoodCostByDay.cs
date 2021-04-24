namespace BusinessLogic.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FoodCostByDay
    {
        [Key]
        public int Id { get; set; }

        public decimal Count { get; set; } = 200;

        public DateTime StartAppointmentDateTime { get; set; } = new DateTime(2019, 01, 01);

        public DateTime FinishAppointmentDateTime { get; set; } = new DateTime(2021, 04, 20);
    }
}
