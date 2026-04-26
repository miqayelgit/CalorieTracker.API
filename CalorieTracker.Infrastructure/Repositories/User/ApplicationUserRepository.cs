using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

internal class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(DatabaseContext context) : base(context)
    {

    }

}
