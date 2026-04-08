
using CalorieTracker.Application.Contracts;
using CalorieTracker.Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories;

public class AplicationUserRoleRepository : RepositoryBase<AplicationUserRole>, IAplicationUserRoleRepository
{
    public AplicationUserRoleRepository(DatabaseContext context) : base(context)
    {
    }
}
