namespace Algorithm
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int firstWorkDay = 3;
            int lastWorkDay = 30;
            int[] weekend = new int[9] { 4, 5, 11, 12, 18, 19, 22, 25, 26 };
            int[] sickDay = new int[7] { 6, 7, 8, 9, 10, 11, 12 };
            decimal foodCostFirst = 200;
            decimal foodCostSecond = 300;
            int threshold = 20;

            var noWorkedDay = new List<int>();

            foreach (int day in weekend)
            {
                noWorkedDay.Add(day);
            }

            foreach (int day in sickDay)
            {
                noWorkedDay.Add(day);
            }

            decimal totalCost = 0;

            for (int i = firstWorkDay; i <= lastWorkDay; i++)
            {
                if (!noWorkedDay.Contains(i))
                {
                    if (i < threshold)
                    {
                        totalCost += foodCostFirst;
                    }
                    else
                    {
                        totalCost += foodCostSecond;
                    }
                }
            }

            Console.WriteLine($"Работнику Иванову полагается на питание {totalCost} руб.");
            Console.ReadLine();
        }
    }
}
