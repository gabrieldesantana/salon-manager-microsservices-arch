using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Refit;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Features.Employees.Commands.Delete;
using SalonManager.Business.Infrastructure.Context;
using SalonManager.Business.Infrastructure.Refit;
using SalonManager.Business.Infrastructure.Repositories;

namespace SalonManager.Business.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddValidatorsFromAssembly(typeof(DeleteEmployeeRequestValidator).Assembly);
        }

        public static void AddRefit(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration["Servicos:Users:Url"];

            services.AddRefitClient<IAppointmentServiceRefit>().ConfigureHttpClient(c =>
            {

                c.BaseAddress = new Uri(host);
                c.DefaultRequestHeaders.UserAgent.ParseAdd("SalonManager.Customers.Api");
            });
        }

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddScoped<DbSession>();

            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            services.AddScoped<ISalonServiceQueryRepository, SalonServiceQueryRepository>();
            services.AddScoped<IEmployeeQueryRepository, EmployeeQueryRepository>();

            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ISalonServiceCommandRepository, SalonServiceCommandRepository>();
            services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();

            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        }
    }
}
