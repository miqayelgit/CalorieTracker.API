
using CalorieTracker.Domain.Entities.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;

namespace CalorieTracker.Application.Contracts.Services.ActivityGoals;

public interface IFitnessGoalService
{
    Task SeedAsync();
    Task<List<FitnessGoalDto>> GetFitnessGoalsAsync();
}
