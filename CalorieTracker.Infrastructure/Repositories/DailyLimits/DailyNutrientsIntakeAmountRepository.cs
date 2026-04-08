using CalorieTracker.Application.Contracts;
using CalorieTracker.Domain.Entities.DailyLimits;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.DailyLimits;

public class DailyNutrientsIntakeAmountRepository : RepositoryBase<DailyNutrientsIntakeAmount>, IDailyNutrientsIntakeAmountRepository
{
    public DailyNutrientsIntakeAmountRepository(DatabaseContext context) : base(context)
    {
    }
}
