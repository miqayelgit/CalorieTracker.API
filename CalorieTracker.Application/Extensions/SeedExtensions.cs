using CalorieTracker.Application.Contracts.Services.Seed;
using CalorieTracker.Application.Services.Seed;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieTracker.Application.Extensions;

public static class SeedExtensions
{
    public static IServiceCollection AddSeedServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationRoleSeedService, ApplicationRoleSeedService>();
        services.AddScoped<IActivityLevelSeedService, ActivityLevelSeedService>();
        services.AddScoped<IFitnessGoalSeedService, FitnessGoalSeedService>();

        return services;
    }
}
