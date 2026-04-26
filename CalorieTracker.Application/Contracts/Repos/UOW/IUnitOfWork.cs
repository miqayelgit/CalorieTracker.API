using CalorieTracker.Application.Contracts.Repos.User;

namespace CalorieTracker.Application.Contracts.Repos.UOW;

public interface IUnitOfWork
{
    IApplicationRoleRepository RoleRepository { get; }
    
    public Task<int> CommitAsync();
}