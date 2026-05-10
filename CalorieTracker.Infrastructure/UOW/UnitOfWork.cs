using CalorieTracker.Application.Contracts.Repos.ActivityGoals;
using CalorieTracker.Application.Contracts.Repos.Products;
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Infrastructure.Context;
using CalorieTracker.Infrastructure.Repositories.ActivityGoals;
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

    private IApplicationRoleRepository? _roleRepository;
    public IApplicationRoleRepository RoleRepository => _roleRepository ??= new ApplicationRoleRepository(_context);

    private IActivityLevelRepository? _activityLevelRepository;
    public IActivityLevelRepository ActivityLevelRepository => _activityLevelRepository ??= new ActivityLevelRepository(_context);

    private IFitnessGoalRepository? _fitnessGoalRepository;
    public IFitnessGoalRepository FitnessGoalRepository => _fitnessGoalRepository ??= new FitnessGoalRepository(_context);

    private IApplicationUserDataRepository? _applicationUserDataService;
    public IApplicationUserDataRepository ApplicationUserDataRepository => _applicationUserDataService ??= new ApplicationUserDataRepository(_context);

    private IProductRepository? _productRepository;
    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}