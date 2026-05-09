using System.Text;
using CalorieTracker.API.Filters;
using CalorieTracker.API.Middlewares;
using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Extensions;
using CalorieTracker.Application.Options;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Infrastructure.Context;
using CalorieTracker.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DatabaseContext>(options => options
    .UseSqlServer(connectionString, b => b.MigrationsAssembly("CalorieTracker.Infrastructure")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                 }
            },
            Array.Empty< string>()
        }
    });
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services
    .AddInfrastructureServices()
    .AddApplicationServices();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var secretKey = builder.Configuration["JwtOptions:SecretKey"];
    var aud = builder.Configuration["JwtOptions:Audience"];

    options.Audience = aud;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true
    };
});

builder.Services.AddAuthorization();

// builder.Services.AddScoped<AuthorizationFilter>();

var app = builder.Build();

using var scope = app.Services.CreateScope();   
var roleService = scope.ServiceProvider.GetRequiredService<IApplicationRoleService>();
var activityLevelService = scope.ServiceProvider.GetRequiredService<IActivityLevelService>();
var fitnessGoalService = scope.ServiceProvider.GetRequiredService<IFitnessGoalService>();

await roleService.SeedAsync();
await activityLevelService.SeedAsync();
await fitnessGoalService.SeedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
