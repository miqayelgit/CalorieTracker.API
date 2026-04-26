using CalorieTracker.Application.Contracts.Repos.DailyLimits;
using CalorieTracker.Application.Contracts.Repos.Products;
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Infrastructure.Context;
using CalorieTracker.Infrastructure.Repositories.DailyLimits;
using CalorieTracker.Infrastructure.Repositories.Products;
using CalorieTracker.Infrastructure.Repositories.User;

namespace CalorieTracker.Infrastructure.UOW;

internal class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}