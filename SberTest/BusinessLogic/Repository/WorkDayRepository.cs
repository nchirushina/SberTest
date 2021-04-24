namespace BusinessLogic.Repository
{
    using System.Linq;
    using BusinessLogic.Entities;

    public class WorkDayRepository : IWorkDayRepository
    {
        private readonly SberTestDbContext sberTestDbContext;

        public WorkDayRepository(SberTestDbContext sberTestDbContext)
        {
            this.sberTestDbContext = sberTestDbContext;
        }

        public IQueryable<WorkDay> GetAll()
        {
            return this.sberTestDbContext.WorkDays;
        }
    }
}
