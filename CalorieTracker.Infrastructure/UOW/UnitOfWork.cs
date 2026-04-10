using CalorieTracker.Application.Contracts.Repos.ActivityGoals;
using CalorieTracker.Application.Contracts.Repos.DailyLimits;
using CalorieTracker.Application.Contracts.Repos.Products;
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Infrastructure.Repositories.ActivityGoals;
using CalorieTracker.Infrastructure.Repositories.DailyLimits;
using CalorieTracker.Infrastructure.Repositories.Products;
using CalorieTracker.Infrastructure.Repositories.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.UOW;

internal class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    private IProductRepository _productRepository;
    private IDailyCalorieLimitRepository _dailyCalorieLimitRepository;
    private IDailyNutrientsIntakeAmountRepository _dailyNutrientsIntakeAmountRepository;
    private IActivityLevelRepository _activityLevelRepository;
    private IFitnessGoalRepository _fitnessGoalRepository;
    private IApplicationUserDataRepository _applicationUserDataRepository;

    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
    public IDailyCalorieLimitRepository DailyCalorieLimitRepository => _dailyCalorieLimitRepository ??= new DailyCalorieLimitRepository(_context);
    public IDailyNutrientsIntakeAmountRepository DailyNutrientsIntakeAmountRepository => _dailyNutrientsIntakeAmountRepository ??= new DailyNutrientsIntakeAmountRepository(_context);
    public IActivityLevelRepository ActivityLevelRepository => _activityLevelRepository ??= new ActivityLevelRepository(_context);
    public IFitnessGoalRepository FitnessGoalRepository => _fitnessGoalRepository ??= new FitnessGoalRepository(_context);
    public IApplicationUserDataRepository ApplicationUserDataRepository => _applicationUserDataRepository ??= new ApplicationUserDataRepository(_context);

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}