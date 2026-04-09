using CalorieTracker.Application.Contracts.DailyLimits;
using CalorieTracker.Domain.Entities.DailyLimits;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.DailyLimits;

internal class DailyCalorieLimitRepository : RepositoryBase<DailyCalorieLimit>, IDailyCalorieLimitRepository
{
    public DailyCalorieLimitRepository(DatabaseContext context) : base(context)
    {
    }
}
