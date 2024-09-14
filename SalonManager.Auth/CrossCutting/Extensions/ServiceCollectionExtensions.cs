using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.Core.Interfaces.Services;
using SalonManager.Auth.Features.Users.Commands.Delete;
using SalonManager.Auth.Infrastructure.Context;
using SalonManager.Auth.Infrastructure.Repositories;
using SalonManager.Auth.Infrastructure.Services.Auth;

namespace SalonManager.Auth.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddValidatorsFromAssembly(typeof(DeleteUserRequestValidator).Assembly);
        }

        ////public static void AddRefit(this IServiceCollection services, IConfiguration configuration)
        ////{
        ////    var host = configuration["Servicos:Users:Url"];

        ////    services.AddRefitClient<IUserServiceRefit>().ConfigureHttpClient(c =>
        ////    {

        ////        c.BaseAddress = new Uri(host);
        ////        c.DefaultRequestHeaders.UserAgent.ParseAdd("SalonManager.Customers.Api");
        ////    });
        ////}

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddScoped<DbSession>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IUserCommandRepository, UserCommandRepository>();

            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
