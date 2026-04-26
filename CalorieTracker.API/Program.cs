using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Extensions;
using CalorieTracker.Infrastructure.Context;
using CalorieTracker.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DatabaseContext>(
    options => options
    .UseSqlServer(connectionString, b => b.MigrationsAssembly("CalorieTracker.Infrastructure")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructureServices()
    .AddApplicationServices();

var app = builder.Build();

using var scope = app.Services.CreateScope();   
var roleService = scope.ServiceProvider.GetRequiredService<IApplicationRoleService>();

await roleService.SeedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
