using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Refit;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.Core.Interfaces.Services;
using SalonManager.Customers.Features.Customers.Commands.Delete;
using SalonManager.Customers.Infrastructure.Auth;
using SalonManager.Customers.Infrastructure.Context;
using SalonManager.Customers.Infrastructure.Refit;
using SalonManager.Customers.Infrastructure.Repositories;

namespace SalonManager.Customers.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddValidatorsFromAssembly(typeof(DeleteCustomerRequestValidator).Assembly);
        }

        public static void AddRefit(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration["Servicos:Users:Url"];

            services.AddRefitClient<IUserServiceRefit>().ConfigureHttpClient(c =>
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
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();

            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
