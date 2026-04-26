using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

internal class AplicationUserRoleRepository : RepositoryBase<ApplicationUserRole>, IAplicationUserRoleRepository
{
    public AplicationUserRoleRepository(DatabaseContext context) : base(context)
    {
    }
}
