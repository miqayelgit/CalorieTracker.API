using CalorieTracker.Application.Contracts.Repos.User;
using Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

internal class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
{
    public ApplicationRoleRepository(DatabaseContext context) : base(context)
    {
    }
}
