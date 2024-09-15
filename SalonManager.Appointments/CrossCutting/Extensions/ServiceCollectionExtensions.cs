using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Refit;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Features.Appointments.Commands.Delete;
using SalonManager.Appointments.Infrastructure.Context;
using SalonManager.Appointments.Infrastructure.Refit;
using SalonManager.Appointments.Infrastructure.Repositories;

namespace SalonManager.Appointments.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddValidatorsFromAssembly(typeof(DeleteAppointmentRequestValidator).Assembly);
        }

        public static void AddRefit(this IServiceCollection services, IConfiguration configuration)
        {
            var hostCustomerService = configuration["Servicos:Customers:Url"];

            services.AddRefitClient<ICustomerServiceRefit>().ConfigureHttpClient(c =>
            {

                c.BaseAddress = new Uri(hostCustomerService!);
                c.DefaultRequestHeaders.UserAgent.ParseAdd("SalonManager.Appointments.Api");
            });

            var hostSalonService = configuration["Servicos:SalonServices:Url"];

            services.AddRefitClient<ISalonServiceServiceRefit>().ConfigureHttpClient(c =>
            {

                c.BaseAddress = new Uri(hostSalonService!);
                c.DefaultRequestHeaders.UserAgent.ParseAdd("SalonManager.Appointments.Api");
            });

            var hostEmployeeService = configuration["Servicos:Employees:Url"];

            services.AddRefitClient<IEmployeeServiceRefit>().ConfigureHttpClient(c =>
            {

                c.BaseAddress = new Uri(hostEmployeeService!);
                c.DefaultRequestHeaders.UserAgent.ParseAdd("SalonManager.Appointments.Api");
            });
        }

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddScoped<DbSession>();
            services.AddScoped<IAppointmentQueryRepository, AppointmentQueryRepository>();
            services.AddScoped<IAppointmentCommandRepository, AppointmentCommandRepository>();

        }
    }
}
