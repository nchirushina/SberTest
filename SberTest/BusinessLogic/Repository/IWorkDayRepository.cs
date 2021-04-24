namespace BusinessLogic.Repository
{
    using System.Linq;
    using BusinessLogic.Entities;

    public interface IWorkDayRepository
    {
        IQueryable<WorkDay> GetAll();
    }
}