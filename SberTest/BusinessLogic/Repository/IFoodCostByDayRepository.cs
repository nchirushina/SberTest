namespace BusinessLogic.Repository
{
    using System.Linq;
    using BusinessLogic.Entities;

    public interface IFoodCostByDayRepository
    {
        IQueryable<FoodCostByDay> GetAll();
    }
}