using CalorieTracker.Application.Contracts.User;
using Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(DatabaseContext context) : base(context)
    {

    }

}
