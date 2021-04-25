namespace BusinessLogic.Repository
{
    using System.Linq;
    using BusinessLogic.Entities;

    public interface IEmployeeRepository
    {
        Employee Get(int id);

        IQueryable<Employee> GetAll();
    }
}
