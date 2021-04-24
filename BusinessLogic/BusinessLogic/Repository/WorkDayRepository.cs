namespace BusinessLogic.Repository
{
    using BusinessLogic.Entities;
    using System.Linq;

    public class WorkDayRepository
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
