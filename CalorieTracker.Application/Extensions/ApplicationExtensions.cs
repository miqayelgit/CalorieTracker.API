using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Application.Contracts.Services.Security;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Options;
using CalorieTracker.Application.Services.Security;
using CalorieTracker.Application.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieTracker.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationRoleService, ApplicationRoleService>();
        services.AddScoped<IApplicationUserService, ApplicationUserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IActivityLevelService, ActivityLevelService>();
        services.AddScoped<IFitnessGoalService, FitnessGoalService>();
        services.AddScoped<IApplicationUserDataService, ApplicationUserDataService>();

        return services;
    }

    public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(_ => configuration.GetSection("JwtOptions"));
        return services; 
    }
}

