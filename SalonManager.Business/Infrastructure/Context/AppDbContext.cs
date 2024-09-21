using Microsoft.EntityFrameworkCore;
using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalonService> SalonServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            ////var connectionString = _configuration.GetConnectionString("Database");
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("SalonManager.Business"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public void SeedData()
        {
            if (!Companies.Any())
            {
                var company = new Company
                (
                    tenantId: Guid.Parse("a331a840-1a80-4d02-bb3f-303888d6c8ab"),
                    userCreatorId: Guid.Parse("8a9b7723-a1fa-426a-896a-bf43d2943c0b"),
                    "Salon Manager LTDA",
                    "97.307.953/0001-39"
                );
                company.Id = Guid.Parse("907f1a9f-4468-48bc-9e7d-2473e85d5760");
                Companies.Add(company);
                SaveChanges();
            }

            if (!Employees.Any())
            {
                Employees.Add(new Employee
                (
                    tenantId: Guid.Parse("a331a840-1a80-4d02-bb3f-303888d6c8ab"),
                    userCreatorId: Guid.Parse("8a9b7723-a1fa-426a-896a-bf43d2943c0b"),
                    userId: Guid.Parse("aed53f95-9d39-4b78-b08d-3d0cde64e086"),
                    companyId: Guid.Parse("907f1a9f-4468-48bc-9e7d-2473e85d5760"),
                    "989.023.780-63",
                    "Roberta Santos Funcionaria",
                    "Roberta",
                    "Feminino",
                    DateTime.SpecifyKind(DateTime.Now.AddYears(-20), DateTimeKind.Unspecified),
                    "+5579998738234"
                ));
                SaveChanges();
            }

            if (!SalonServices.Any())
            {
                SalonServices.Add(new SalonService
                (
                    tenantId: Guid.Parse("a331a840-1a80-4d02-bb3f-303888d6c8ab"),
                    userCreatorId: Guid.Parse("8a9b7723-a1fa-426a-896a-bf43d2943c0b"),
                    "Corte Masculino Cabelo P",
                    "Cabelo",
                    30
                ));

                SaveChanges();
            }
        }
    }
}
