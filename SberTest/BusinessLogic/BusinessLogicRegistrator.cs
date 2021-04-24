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
            services.AddTransient<IFoodCostByDayRepository, FoodCostByDayRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IWorkDayRepository, WorkDayRepository>();
            services.AddTransient<IFoodCostCalcService, FoodCostCalcService>();
            services.AddDbContext<SberTestDbContext>(option => option.UseSqlServer(connectionString));

            return services;
        }
    }
}
