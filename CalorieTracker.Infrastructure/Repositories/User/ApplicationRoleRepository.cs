using CalorieTracker.Application.Contracts.Repos.User;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

internal class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
{
    public ApplicationRoleRepository(DatabaseContext context) : base(context)
    {
    }
}
