namespace BusinessLogic
{
    using BusinessLogic.Entities;
    using Microsoft.EntityFrameworkCore;

    public class SberTestDbContext : DbContext
    {
        public SberTestDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeersWorkDays> Timesheets { get; set; }

        public DbSet<WorkDay> WorkDays { get; set; }

        public DbSet<FoodCostByDay> FoodCosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeersWorkDays>().HasKey(ewd => new { ewd.EmployeeId, ewd.WorkDayId });
        }
    }
}
