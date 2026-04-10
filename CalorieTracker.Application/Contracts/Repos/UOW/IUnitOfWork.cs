using CalorieTracker.Application.Contracts.Repos.ActivityGoals;
using CalorieTracker.Application.Contracts.Repos.DailyLimits;
using CalorieTracker.Application.Contracts.Repos.Products;
using CalorieTracker.Application.Contracts.Repos.User;

namespace CalorieTracker.Application.Contracts.Repos.UOW;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public IDailyCalorieLimitRepository DailyCalorieLimitRepository { get; }
    public IDailyNutrientsIntakeAmountRepository DailyNutrientsIntakeAmountRepository { get; }
    public IActivityLevelRepository ActivityLevelRepository { get; }
    public IFitnessGoalRepository FitnessGoalRepository { get; }
    public IApplicationUserDataRepository ApplicationUserDataRepository { get; }
    public Task<int> CommitAsync();
}