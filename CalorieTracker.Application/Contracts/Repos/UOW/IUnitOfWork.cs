using CalorieTracker.Application.Contracts.Repos.ActivityGoals;
using CalorieTracker.Application.Contracts.Repos.DailyLimits;
using CalorieTracker.Application.Contracts.Repos.Products;
using CalorieTracker.Application.Contracts.Repos.User;

namespace CalorieTracker.Application.Contracts.Repos.UOW;

public interface IUnitOfWork
{
    IApplicationRoleRepository RoleRepository { get; }
    IActivityLevelRepository ActivityLevelRepository { get; }
    IFitnessGoalRepository FitnessGoalRepository { get; }
    IApplicationUserDataRepository ApplicationUserDataRepository { get; }
    IProductRepository ProductRepository{ get; }
    IDailyNutrientsIntakeAmountRepository DailyNutrientsIntakeAmountRepository { get; }

    IDailyCalorieLimitRepository DailyCalorieLimitRepository { get; }
    public Task<int> CommitAsync();
}