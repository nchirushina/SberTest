namespace AdvanceAlgorithm.Global
{
    using System;
    using System.Linq;
    using AdvanceAlgorithm.Models;
    
    public static class GlobalFunctions
    {
        public static int WorkDays(string actionComment, DateTime firstDay, DateTime lastDay)
        {
            int workedOutDays = 0;

            var dayDifference = (int)lastDay.Subtract(firstDay).TotalDays + 1;
            workedOutDays = Enumerable
                .Range(0, dayDifference)
                .Select(cd => firstDay.AddDays(cd))
                .Count(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday);

            if (actionComment != "")
            {
                throw new Exception("Some comment in function 'WorkDays'.");
            }

            return workedOutDays;
        }

        public static int PlanDays(string actionComment, DateTime firstDay, DateTime lastDay)
        {
            int workedOutDays = 0;

            for (var currentDay = firstDay; currentDay <= lastDay; currentDay = currentDay.AddDays(1))
            {
                switch (currentDay.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Saturday:
                        break;
                    default:
                        workedOutDays++;
                        break;
                }
            }

            switch (actionComment)
            {
                case "":
                    break;

                case "1":
                    workedOutDays--;
                    break;

                case "2":
                    workedOutDays -= 2;
                    break;

                case "5":
                    workedOutDays -= 5;
                    break;

                default:
                    throw new Exception("Some comment in function 'PlanDays'.");

            }

            return workedOutDays;
        }

        public static decimal GetSalary(Employee employee)
        {
            return employee.Salary;
        }
    }
}
