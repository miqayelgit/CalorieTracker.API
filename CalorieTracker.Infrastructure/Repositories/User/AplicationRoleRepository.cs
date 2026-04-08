using CalorieTracker.Application.Contracts.User;
using Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

public class AplicationRoleRepository : RepositoryBase<AplicationRole>, IAplicationRoleRepository
{
    public AplicationRoleRepository(DatabaseContext context) : base(context)
    {
    }
}
