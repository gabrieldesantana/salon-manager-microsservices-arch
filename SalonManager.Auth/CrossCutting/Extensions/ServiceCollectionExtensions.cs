﻿using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.Core.Interfaces.Services;
using SalonManager.Auth.Features.Users.Commands.Delete;
using SalonManager.Auth.Infrastructure.Context;
using SalonManager.Auth.Infrastructure.Repositories;
using SalonManager.Auth.Infrastructure.Services.Auth;
using System.Text;

namespace SalonManager.Auth.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddValidatorsFromAssembly(typeof(DeleteUserRequestValidator).Assembly);
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
