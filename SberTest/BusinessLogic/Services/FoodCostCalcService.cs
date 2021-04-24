namespace BusinessLogic.Services
{
    using System;
    using System.Linq;
    using BusinessLogic.Enum;
    using BusinessLogic.Repository;
    
    public class FoodCostCalcService : IFoodCostCalcService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IFoodCostByDayRepository foodCostByDayRepository;

        public FoodCostCalcService(
            IEmployeeRepository employeeRepository,
            IFoodCostByDayRepository foodCostByDayRepository)
        {
            this.employeeRepository = employeeRepository;
            this.foodCostByDayRepository = foodCostByDayRepository;
        }

        public decimal ToCalc(int employeeId)
        {
            decimal totalFoodCost = 0;

            var targetEmployee = this.employeeRepository.Get(employeeId);

            foreach (var employeeWorkDay in targetEmployee.Timesheet)
            {
                var dateOfWorkDay = employeeWorkDay.WorkDay.DateOfWorkDay;
                var workDayStatus = employeeWorkDay.WorkDay.WorkDayStatus;

                if (workDayStatus == EWorkDayStatus.WorkingDay)
                {
                    var foodCost = this.foodCostByDayRepository.GetAll().FirstOrDefault(
                        fc => dateOfWorkDay >= fc.StartAppointmentDateTime
                              && dateOfWorkDay <= fc.FinishAppointmentDateTime);
                    
                    if(foodCost is null)
                    {
                        throw new Exception($"There is no food cost for date: {dateOfWorkDay}");
                    }

                    totalFoodCost += foodCost.Count;
                }
            }

            return totalFoodCost;
        }
    }
}
