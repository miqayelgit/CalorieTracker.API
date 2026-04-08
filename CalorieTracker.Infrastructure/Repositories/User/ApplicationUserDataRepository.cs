using CalorieTracker.Application.Contracts.User;
using CalorieTracker.Domain.Entities.User;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.User;

public class ApplicationUserDataRepository : RepositoryBase<ApplicationUserData>, IApplicationUserDataRepository
{
    public ApplicationUserDataRepository(DatabaseContext context) : base(context)
    {
    }
}
