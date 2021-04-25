namespace AdvanceAlgorithm.Service
{
    using System;
    using AdvanceAlgorithm.Global;
    using AdvanceAlgorithm.Models;
    
    // Original name: Formula_Adv
    public class AdvanceCalculationService
    {
        // action comment - dependance from previous code
        public decimal Advanse(string actionComment, Employee employee, Company company, Period period)
        {
            decimal result = 0;

            if (company.AdvancePercent == 0)
            {
                return result;
            }

            DateTime advanceDate;

            if (company.UseAdvanceDay)
            {
                advanceDate = company.AdvanceDay;
            }
            else
            {
                advanceDate = period.LastDayOfPeriod;
            }

            if (employee.DateEndOfWork <= advanceDate)
            {
                return result;
            }

            var firstDay = period.FirstDayOfPeriod;
            var lastDay = advanceDate;

            var workedOutDays = GlobalFunctions.WorkDays(actionComment, firstDay, lastDay);

            if (workedOutDays < company.MinimalWorkedDayCount)
            {
                return result;
            }

            var salary = GlobalFunctions.GetSalary(employee);

            var planDays = GlobalFunctions.PlanDays(actionComment, firstDay, lastDay);

            result = salary * workedOutDays / planDays * company.AdvancePercent / 100;

            return result;
        }
    }
}
