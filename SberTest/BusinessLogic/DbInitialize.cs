namespace BusinessLogic
{
    using System;
    using BusinessLogic.Entities;
    using BusinessLogic.Enum;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class DbInitializer
    {
        public static void DbInitialize(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var sberTestDb = scope.ServiceProvider.GetService<SberTestDbContext>())
                {
                    sberTestDb.Database.EnsureDeleted();
                    sberTestDb.Database.EnsureCreated();

                    // Employee
                    sberTestDb.Employees.Add(new Employee() { Name = "Ivanov Ivan Ivanovich" });

                    sberTestDb.SaveChanges();

                    //WorkDay
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 03), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 04), WorkDayStatus = EWorkDayStatus.Weekend });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 05), WorkDayStatus = EWorkDayStatus.Weekend });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 06), WorkDayStatus = EWorkDayStatus.SickDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 07), WorkDayStatus = EWorkDayStatus.SickDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 08), WorkDayStatus = EWorkDayStatus.SickDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 09), WorkDayStatus = EWorkDayStatus.SickDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 10), WorkDayStatus = EWorkDayStatus.SickDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 11), WorkDayStatus = EWorkDayStatus.SickDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 12), WorkDayStatus = EWorkDayStatus.SickDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 13), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 14), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 15), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 16), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 17), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 18), WorkDayStatus = EWorkDayStatus.Weekend });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 19), WorkDayStatus = EWorkDayStatus.Weekend });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 20), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 21), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 22), WorkDayStatus = EWorkDayStatus.Weekend });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 23), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 24), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 25), WorkDayStatus = EWorkDayStatus.Weekend });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 26), WorkDayStatus = EWorkDayStatus.Weekend });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 27), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 28), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 29), WorkDayStatus = EWorkDayStatus.WorkingDay });
                    sberTestDb.WorkDays.Add(new WorkDay() { DateOfWorkDay = new DateTime(2020, 04, 30), WorkDayStatus = EWorkDayStatus.WorkingDay });

                    sberTestDb.SaveChanges();

                    //AccountansyFoodRate
                    sberTestDb.FoodCosts.Add(new FoodCostByDay() { Count = 200, StartAppointmentDateTime = new DateTime(2015, 01, 01), FinishAppointmentDateTime = new DateTime(2020, 04, 19) });
                    sberTestDb.FoodCosts.Add(new FoodCostByDay() { Count = 300, StartAppointmentDateTime = new DateTime(2020, 04, 20), FinishAppointmentDateTime = new DateTime(2025, 04, 20) });

                    sberTestDb.SaveChanges();

                    //EmployeersWorkDays
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 1 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 2 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 3 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 4 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 5 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 6 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 7 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 8 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 9 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 10 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 11 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 12 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 13 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 14 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 15 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 16 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 17 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 18 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 19 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 20 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 21 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 22 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 23 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 24 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 25 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 26 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 27 });
                    sberTestDb.Timesheets.Add(new EmployeersWorkDays() { EmployeeId = 1, WorkDayId = 28 });

                    sberTestDb.SaveChanges();
                }
            }
        }
    }
}