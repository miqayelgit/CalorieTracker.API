using CalorieTracker.Application.Contracts.User;
using Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

public class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
{
    public ApplicationRoleRepository(DatabaseContext context) : base(context)
    {
    }
}
