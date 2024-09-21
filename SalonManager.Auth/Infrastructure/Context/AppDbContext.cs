using Microsoft.EntityFrameworkCore;
using SalonManager.Auth.Core.Entities;

namespace SalonManager.Auth.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            ////var connectionString = _configuration.GetConnectionString("Database");
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("SalonManager.Auth"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public void SeedData()
        {
            if (!Users.Any())
            {
                Users.Add(new User
                (
                    "Gabriel de Santana Gomes",
                    "gabriel.gomes",
                    "gabrieldesantana.contato@gmail.com",
                    "ca46c17d99836b965fa2d5e4eaaa69f90007796500063b8b2bf5c8cc289eb9a7",
                    Core.Enums.EUserRole.Admin
                ));

                Users.Add(new User
                (
                    "Maria Silva da Proprietaria",
                    "maria.silva",
                    "maria.silva@teste.com",
                    "ca46c17d99836b965fa2d5e4eaaa69f90007796500063b8b2bf5c8cc289eb9a7",
                    Core.Enums.EUserRole.Owner
                ));

                var userEmployee = new User
                (
                    "Roberta Santos Cliente",
                    "roberta.santos",
                    "roberta.santos@teste.com",
                    "ca46c17d99836b965fa2d5e4eaaa69f90007796500063b8b2bf5c8cc289eb9a7",
                    Core.Enums.EUserRole.Employee
                );
                userEmployee.Id = Guid.Parse("aed53f95-9d39-4b78-b08d-3d0cde64e086");
                Users.Add(userEmployee);

                SaveChanges();
            }
        }
    }
}
