namespace XBusinessLogicTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusinessLogic.Entities;
    using BusinessLogic.Enum;
    using BusinessLogic.Repository;
    using BusinessLogic.Services;
    using Moq;
    using Xunit;

    public class FoodCostCalcServiceTest
    {
        [Fact]
        public void ShouldReturnCertainValue()
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var foodCostByDayRepositoryMock = new Mock<IFoodCostByDayRepository>();
            var sut = new FoodCostCalcService(
                employeeRepositoryMock.Object,
                foodCostByDayRepositoryMock.Object);
            
            var targetEmployeeId = 5;
            decimal expectedResult = 77;
            var foodCosts = this.GetFoodCosts();
            var targetEmployee = this.GetTargetEmployee(targetEmployeeId);

            employeeRepositoryMock
                .Setup(erm => erm.Get(targetEmployeeId))
                .Returns(targetEmployee);
            foodCostByDayRepositoryMock
                .Setup(fcm => fcm.GetAll())
                .Returns(foodCosts);

            //Act
            var result = sut.ToCalc(targetEmployeeId);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnException()
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var foodCostByDayRepositoryMock = new Mock<IFoodCostByDayRepository>();
            var sut = new FoodCostCalcService(
                employeeRepositoryMock.Object,
                foodCostByDayRepositoryMock.Object);
            
            var targetEmployeeId = 5;
            var targetEmployee = GetTargetEmployee(targetEmployeeId);
            var foodCosts = GetWrongFoodCosts();

            employeeRepositoryMock
                .Setup(erm => erm.Get(targetEmployeeId))
                .Returns(targetEmployee);
            foodCostByDayRepositoryMock
                .Setup(fcm => fcm.GetAll())
                .Returns(foodCosts);

            //Act
            //Assert
            Assert.Throws<Exception>(
                () => sut.ToCalc(targetEmployeeId));
        }

        private IQueryable<FoodCostByDay> GetWrongFoodCosts()
        {
            var listOfFoodCosts = new List<FoodCostByDay>();

            listOfFoodCosts.Add(new FoodCostByDay() { Count = 11, StartAppointmentDateTime = new DateTime(2021, 4, 10), FinishAppointmentDateTime = new DateTime(2021, 4, 12) });
            // excluded next entry
            // listOfFoodCosts.Add(new FoodCostByDay() { Count = 22, StartAppointmentDateTime = new DateTime(2021, 4, 13), FinishAppointmentDateTime = new DateTime(2021, 4, 15) });
            listOfFoodCosts.Add(new FoodCostByDay() { Count = 33, StartAppointmentDateTime = new DateTime(2021, 4, 16), FinishAppointmentDateTime = new DateTime(2021, 4, 18) });

            return listOfFoodCosts.AsQueryable();
        }

        private IQueryable<FoodCostByDay> GetFoodCosts()
        {
            var listOfFoodCosts = new List<FoodCostByDay>();

            listOfFoodCosts.Add(new FoodCostByDay() { Count = 11, StartAppointmentDateTime = new DateTime(2021, 4, 10), FinishAppointmentDateTime = new DateTime(2021, 4, 12) });
            listOfFoodCosts.Add(new FoodCostByDay() { Count = 22, StartAppointmentDateTime = new DateTime(2021, 4, 13), FinishAppointmentDateTime = new DateTime(2021, 4, 15) });
            listOfFoodCosts.Add(new FoodCostByDay() { Count = 33, StartAppointmentDateTime = new DateTime(2021, 4, 16), FinishAppointmentDateTime = new DateTime(2021, 4, 18) });

            return listOfFoodCosts.AsQueryable();
        }

        private Employee GetTargetEmployee(int id)
        {
            var listOfWorkDays = new Queue<WorkDay>();

            listOfWorkDays.Enqueue(new WorkDay() { DateOfWorkDay = new DateTime(2021, 4, 11), WorkDayStatus = EWorkDayStatus.WorkingDay });  //11 + =11
            listOfWorkDays.Enqueue(new WorkDay() { DateOfWorkDay = new DateTime(2021, 4, 12), WorkDayStatus = EWorkDayStatus.WorkingDay });  //11 + =22
            listOfWorkDays.Enqueue(new WorkDay() { DateOfWorkDay = new DateTime(2021, 4, 13), WorkDayStatus = EWorkDayStatus.Weekend });     //22
            listOfWorkDays.Enqueue(new WorkDay() { DateOfWorkDay = new DateTime(2021, 4, 14), WorkDayStatus = EWorkDayStatus.WorkingDay });  //22 + =44
            listOfWorkDays.Enqueue(new WorkDay() { DateOfWorkDay = new DateTime(2021, 4, 15), WorkDayStatus = EWorkDayStatus.SickDay });     //22
            listOfWorkDays.Enqueue(new WorkDay() { DateOfWorkDay = new DateTime(2021, 4, 16), WorkDayStatus = EWorkDayStatus.WorkingDay });  //33 + =77.
            listOfWorkDays.Enqueue(new WorkDay() { DateOfWorkDay = new DateTime(2021, 4, 17), WorkDayStatus = EWorkDayStatus.VacationDay }); //33

            var timesheet = new List<EmployeersWorkDays>();

            timesheet.Add(new EmployeersWorkDays() { EmployeeId = id, WorkDayId = 1, WorkDay = listOfWorkDays.Dequeue() });
            timesheet.Add(new EmployeersWorkDays() { EmployeeId = id, WorkDayId = 2, WorkDay = listOfWorkDays.Dequeue() });
            timesheet.Add(new EmployeersWorkDays() { EmployeeId = id, WorkDayId = 3, WorkDay = listOfWorkDays.Dequeue() });
            timesheet.Add(new EmployeersWorkDays() { EmployeeId = id, WorkDayId = 4, WorkDay = listOfWorkDays.Dequeue() });
            timesheet.Add(new EmployeersWorkDays() { EmployeeId = id, WorkDayId = 5, WorkDay = listOfWorkDays.Dequeue() });
            timesheet.Add(new EmployeersWorkDays() { EmployeeId = id, WorkDayId = 6, WorkDay = listOfWorkDays.Dequeue() });
            timesheet.Add(new EmployeersWorkDays() { EmployeeId = id, WorkDayId = 7, WorkDay = listOfWorkDays.Dequeue() });

            var targetEmployee = new Employee() { Id = id, Name = "Ludmila Petrova", Timesheet = timesheet };

            return targetEmployee;
        }
    }
}
