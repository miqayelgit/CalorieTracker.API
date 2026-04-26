namespace CalorieTracker.Application.Contracts.Repos.UOW;

public interface IUnitOfWork
{
    public Task<int> CommitAsync();
}