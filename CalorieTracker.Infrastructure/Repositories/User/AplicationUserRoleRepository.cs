using CalorieTracker.Application.Contracts.User;
using CalorieTracker.Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

public class AplicationUserRoleRepository : RepositoryBase<AplicationUserRole>, IAplicationUserRoleRepository
{
    public AplicationUserRoleRepository(DatabaseContext context) : base(context)
    {
    }
}
