using Microsoft.EntityFrameworkCore;
using SalonManager.Appointments.CrossCutting.Extensions;
using SalonManager.Appointments.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRefit(builder.Configuration);
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddApplication();

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
await using var db = scope.ServiceProvider.GetService<AppDbContext>();
await db.Database.MigrateAsync();
//db.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
