using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace CalorieTracker.Infrastructure.Repositories.User;

internal class ApplicationUserDataRepository : RepositoryBase<ApplicationUserData>, IApplicationUserDataRepository
{
    public ApplicationUserDataRepository(DatabaseContext context) : base(context)
    {
        
    }

    public Task<ApplicationUserData?> GetUserFullData(Expression<Func<ApplicationUserData, bool>>? expression = null)
    {
        if (expression == null)
        {
            return Context.Set<ApplicationUserData>()
                .Include(x => x.User) 
                .FirstOrDefaultAsync();
        }

        return Context.Set<ApplicationUserData>()
                .Include(x => x.User)
                .FirstOrDefaultAsync(expression);
    }
}
