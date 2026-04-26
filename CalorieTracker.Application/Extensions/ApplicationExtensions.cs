using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieTracker.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationRoleService, ApplicationRoleService>();

        return services;
    }
}