using CalorieTracker.Application.Contracts.ActivityGoals;
using CalorieTracker.Domain.Entities.ActivityGoals;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.ActivityGoals;

internal class FitnessGoalRepository : RepositoryBase<FitnessGoal>, IFitnessGoalRepository
{
    public FitnessGoalRepository(DatabaseContext context) : base(context)
    {
    }
}
