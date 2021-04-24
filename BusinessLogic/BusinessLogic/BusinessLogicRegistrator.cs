namespace BusinessLogic
{
    using BusinessLogic.Repository;
    using BusinessLogic.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessLogicRegistrator
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<FoodCostByDayRepository, FoodCostByDayRepository>();
            services.AddTransient<EmployeeRepository, EmployeeRepository>();
            services.AddTransient<WorkDayRepository, WorkDayRepository>();
            services.AddTransient<IFoodCostCalcService, FoodCostCalcService>();
            services.AddDbContext<SberTestDbContext>(option => option.UseSqlServer(connectionString));

            return services;
        }
    }
}
