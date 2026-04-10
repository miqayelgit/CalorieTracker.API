using CalorieTracker.Application.Contracts.Repos.User;
using Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

internal class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(DatabaseContext context) : base(context)
    {

    }

}
