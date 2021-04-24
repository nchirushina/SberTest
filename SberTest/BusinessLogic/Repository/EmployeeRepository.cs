namespace BusinessLogic.Repository
{
    using System.Linq;
    using BusinessLogic.Entities;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeRepository : IEmployeeRepository
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
