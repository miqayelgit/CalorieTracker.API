using CalorieTracker.API.DtoValidators.Auth;
using CalorieTracker.API.Middlewares;
using CalorieTracker.Application.Contracts.Services.Seed;
using CalorieTracker.Application.Extensions;
using CalorieTracker.Application.Options;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Infrastructure.Context;
using CalorieTracker.Infrastructure.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Security.Claims;
using System.Text;
using Worker_Service;

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
    .AddApplicationServices()
    .AddSeedServices();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value!.Errors.Count > 0)
            .Select(x => new
            {
                Field = x.Key,
                Errors = x.Value!.Errors.Select(e => e.ErrorMessage)
            });

        return new BadRequestObjectResult(new
        {
            Success = false,
            Message = "Validation failed",
            Name = "Poghos",
            Errors = errors
        });
    };
});
builder.Services.AddValidatorsFromAssembly(typeof(SignInDtoValidator).Assembly);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
    var secretKey = jwtOptions!.Secret;
    var aud = jwtOptions.Audience;
    var issuer = jwtOptions.Issuer;

    options.Audience = aud;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = issuer,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        RoleClaimType = ClaimTypes.Role
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = ctx =>
        {
            ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();
builder.Services.AddHostedService<Worker>();
builder.Services.AddHttpClient();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var roleSeedService = scope.ServiceProvider.GetRequiredService<IApplicationRoleSeedService>();
var activityLevelSeedService = scope.ServiceProvider.GetRequiredService<IActivityLevelSeedService>();
var fitnessGoalSeedService = scope.ServiceProvider.GetRequiredService<IFitnessGoalSeedService>();

await roleSeedService.SeedAsync();
await activityLevelSeedService.SeedAsync();
await fitnessGoalSeedService.SeedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
