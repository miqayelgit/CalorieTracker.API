using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Infrastructure.UOW;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieTracker.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}