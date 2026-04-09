using CalorieTracker.Application.Contracts.ActivityGoals;
using CalorieTracker.Application.Contracts.DailyLimits;
using CalorieTracker.Application.Contracts.Products;
using CalorieTracker.Application.Contracts.User;
namespace CalorieTracker.Application.Contracts.UOW;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get;}
    public IDailyCalorieLimitRepository DailyCalorieLimitRepository { get; }
    public IDailyNutrientsIntakeAmountRepository DailyNutrientsIntakeAmountRepository { get; }
    public IActivityLevelRepository ActivityLevelRepository { get; }
    public IFitnessGoalRepository FitnessGoalRepository { get; }
    public IApplicationUserDataRepository ApplicationUserDataRepository { get; }
}