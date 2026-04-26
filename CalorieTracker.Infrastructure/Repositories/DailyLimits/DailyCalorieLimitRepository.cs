using CalorieTracker.Application.Contracts.Repos.DailyLimits;
using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.DailyLimits;

internal class DailyCalorieLimitRepository : RepositoryBase<DailyCalorieLimit>, IDailyCalorieLimitRepository
{
    public DailyCalorieLimitRepository(DatabaseContext context) : base(context)
    {
    }
}
