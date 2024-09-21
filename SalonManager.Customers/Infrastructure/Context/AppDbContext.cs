using Microsoft.EntityFrameworkCore;
using SalonManager.Customers.Core.Entities;

namespace SalonManager.Customers.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            _configuration = configuration;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            ////var connectionString = _configuration.GetConnectionString("Database");
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("SalonManager.Customers"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
