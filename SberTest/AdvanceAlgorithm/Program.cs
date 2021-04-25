namespace AdvanceAlgorithm
{
    using System;
    using AdvanceAlgorithm.Models;
    using AdvanceAlgorithm.Service;
    
    class Program
    {
        static void Main()
        {
            var ivanov = new Employee() { DateBeginOfWork = new DateTime(2000, 01, 01), DateEndOfWork = new DateTime(2030, 12, 31), Salary = 50000 };
            var april = new Period() { FirstDayOfPeriod = new DateTime(2021, 04, 01), LastDayOfPeriod = new DateTime(2021, 04, 30) };
            var hornsAndHooves = new Company() { AdvancePercent = 50, MinimalWorkedDayCount = 7, UseAdvanceDay = false };

            var ivanovApril = new AdvanceCalculationService();

            Console.WriteLine($"{ivanovApril.Advanse("", ivanov, hornsAndHooves, april)}");
            Console.ReadLine();
        }
    }
}
