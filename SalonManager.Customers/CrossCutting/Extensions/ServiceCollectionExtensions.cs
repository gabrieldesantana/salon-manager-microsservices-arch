﻿using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refit;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.Core.Interfaces.Services;
using SalonManager.Customers.Features.Customers.Commands.Delete;
using SalonManager.Customers.Infrastructure.Auth;
using SalonManager.Customers.Infrastructure.Context;
using SalonManager.Customers.Infrastructure.Refit;
using SalonManager.Customers.Infrastructure.Repositories;
using System.Text;

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
            var hostUserService = configuration["Servicos:Users:Url"];

            services.AddRefitClient<IUserServiceRefit>().ConfigureHttpClient(c =>
            {

                c.BaseAddress = new Uri(hostUserService);
                c.DefaultRequestHeaders.UserAgent.ParseAdd("SalonManager.Customers.Api");
            });

            var hostAppointmentService = configuration["Servicos:Appointments:Url"];

            services.AddRefitClient<IAppointmentServiceRefit>().ConfigureHttpClient(c =>
            {

                c.BaseAddress = new Uri(hostAppointmentService!);
                c.DefaultRequestHeaders.UserAgent.ParseAdd("SalonManager.Customers.Api");
            });
        }

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            ////var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddScoped<DbSession>();
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //JWT
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            }); //JWT

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SalonManager.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usando Bearer."

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        } ,
                        new string [] {}
                    }
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });  //JWT
        }
    }
}
