using CalorieTracker.Application.Contracts.Repos.DailyLimits;
using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.DailyLimits;

internal class DailyNutrientsIntakeAmountRepository : RepositoryBase<DailyNutrientsIntakeAmount>, IDailyNutrientsIntakeAmountRepository
{
    public DailyNutrientsIntakeAmountRepository(DatabaseContext context) : base(context)
    {
    }
}
