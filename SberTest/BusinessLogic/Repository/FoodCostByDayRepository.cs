namespace BusinessLogic.Repository
{
    using System.Linq;
    using BusinessLogic.Entities;

    public class FoodCostByDayRepository : IFoodCostByDayRepository
    {
        private readonly SberTestDbContext sberTestDbContext;

        public FoodCostByDayRepository(SberTestDbContext sberTestDbContext)
        {
            this.sberTestDbContext = sberTestDbContext;
        }

        public IQueryable<FoodCostByDay> GetAll()
        {
            return this.sberTestDbContext.FoodCosts;
        }
    }
}
