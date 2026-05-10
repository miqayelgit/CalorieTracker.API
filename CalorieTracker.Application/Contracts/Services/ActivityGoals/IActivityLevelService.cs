using CalorieTracker.Dtos.ActivityGoals;

namespace CalorieTracker.Application.Contracts.Services.ActivityGoals;

public interface IActivityLevelService
{
    Task<List<ActivityLevelDto>> GetActivityLevelsAsync();
}
