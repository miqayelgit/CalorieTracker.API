using CalorieTracker.Application.Contracts.ActivityGoals;
using CalorieTracker.Domain.Entities.ActivityGoals;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.ActivityGoals;

public class ActivityLevelRepository : RepositoryBase<ActivityLevel>, IActivityLevelRepository

{
    public ActivityLevelRepository(DatabaseContext context) : base(context)
    {
    }
}

