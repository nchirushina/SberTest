namespace BusinessLogic.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using BusinessLogic.Entities;
    using BusinessLogic.Enum;
    using BusinessLogic.Repository;

    public class FoodCostCalcService : IFoodCostCalcService
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly FoodCostByDayRepository accountancyFoodRateRepository;

        public FoodCostCalcService(
            EmployeeRepository employeeRepository,
            FoodCostByDayRepository accountancyFoodRateRepository
            )
        {
            this.employeeRepository = employeeRepository;
            this.accountancyFoodRateRepository = accountancyFoodRateRepository;
        }

        public decimal ToCalc(int employeeId)
        {
            decimal totalFoodCost = 0;

            var targetEmployee = this.employeeRepository.Get(employeeId);

            var foodCostList = this.ToListFoodCosts(targetEmployee);

            foreach (var employeeWorkDay in targetEmployee.Timesheet)
            {
                var dateOfWorkDay = employeeWorkDay.WorkDay.DateOfWorkDay;
                var workDayStatus = employeeWorkDay.WorkDay.WorkDayStatus;

                if (workDayStatus == EWorkDayStatus.WorkingDay)
                {
                    foreach (var foodCost in foodCostList)
                    {
                        if (dateOfWorkDay >= foodCost.StartAppointmentDateTime
                            && dateOfWorkDay <= foodCost.FinishAppointmentDateTime)
                        {
                            totalFoodCost += foodCost.Count;
                        }
                    }
                }
            }

            var firstCost = 1;
            var secondCost = 2;
            var thresholdDate = 3;
            var totalCost = 0;
            var lastDay = 30;

            for (int i = 1; i < lastDay; i++)
            {
                if (i < thresholdDate)
                {
                    totalCost += firstCost;
                }
                else
                {
                    totalCost += secondCost;
                }
            }

            return totalFoodCost;
        }

        private ICollection<FoodCostByDay> ToListFoodCosts(Employee targetEmployee)
        {
            var listOfFoodCostForTargetEmployee = new List<FoodCostByDay>();
            var listOfFoodCost = this.accountancyFoodRateRepository.GetAll().ToList();

            var timesheetOfEmployee = targetEmployee.Timesheet;

            var firstWorkedDay = timesheetOfEmployee.First().WorkDay;
            var lastWorkedDay = timesheetOfEmployee.Last().WorkDay;

            foreach (var foodCost in listOfFoodCost)
            {
                if (foodCost.FinishAppointmentDateTime >= firstWorkedDay.DateOfWorkDay
                    || foodCost.StartAppointmentDateTime <= lastWorkedDay.DateOfWorkDay)
                {
                    listOfFoodCostForTargetEmployee.Add(foodCost);
                }
            }

            return listOfFoodCostForTargetEmployee;
        }
    }
}
