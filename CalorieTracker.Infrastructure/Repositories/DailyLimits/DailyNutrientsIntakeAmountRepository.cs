using CalorieTracker.Application.Contracts.DailyLimits;
using CalorieTracker.Domain.Entities.DailyLimits;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.DailyLimits;

internal class DailyNutrientsIntakeAmountRepository : RepositoryBase<DailyNutrientsIntakeAmount>, IDailyNutrientsIntakeAmountRepository
{
    public DailyNutrientsIntakeAmountRepository(DatabaseContext context) : base(context)
    {
    }
}
