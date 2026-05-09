using CalorieTracker.Domain.Entities.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;

namespace CalorieTracker.Application.Contracts.Services.ActivityGoals;

public interface IActivityLevelService
{
    Task SeedAsync();
    Task<List<ActivityLevelDto>> GetActivityLevelsAsync();
}
