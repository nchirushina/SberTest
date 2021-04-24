namespace BusinessLogic.Repository
{
    using BusinessLogic.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class EmployeeRepository
    {
        private readonly SberTestDbContext sberTestDbContext;

        public EmployeeRepository(SberTestDbContext sberTestDbContext)
        {
            this.sberTestDbContext = sberTestDbContext;
        }

        public Employee Get(int id)
        {
            return this.sberTestDbContext.Employees
                .Include(d => d.Timesheet)
                    .ThenInclude(dt => dt.WorkDay)
                .FirstOrDefault(emp => emp.Id == id);
        }

        public IQueryable<Employee> GetAll()
        {
            return this.sberTestDbContext.Employees;
        }
    }
}
