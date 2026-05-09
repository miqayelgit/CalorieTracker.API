using CalorieTracker.Application.Contracts.Repos.ActivityGoals;
using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Application.Contracts.Services.User;

namespace CalorieTracker.Application.Contracts.Repos.UOW;

public interface IUnitOfWork
{
    IApplicationRoleRepository RoleRepository { get; }
    IActivityLevelRepository ActivityLevelRepository { get; }
    IFitnessGoalRepository FitnessGoalRepository { get; }
    IApplicationUserDataRepository ApplicationUserDataRepository { get; }

    public Task<int> CommitAsync();
}