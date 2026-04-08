using CalorieTracker.Application.Contracts;
using CalorieTracker.Domain.Entities.DailyCalorieLimit;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.DailyLimits;

internal class DailyCalorieLimitRepository : RepositoryBase<DailyCalorieLimit>, IDailyCalorieLimitRepository
{
    public DailyCalorieLimitRepository(DatabaseContext context) : base(context)
    {
    }
}
