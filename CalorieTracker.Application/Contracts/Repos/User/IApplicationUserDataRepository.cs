using CalorieTracker.Domain.Entities.User;
using System.Linq.Expressions;

namespace CalorieTracker.Application.Contracts.Repos.User;

public interface IApplicationUserDataRepository : IRepositoryBase<ApplicationUserData>
{
    Task<ApplicationUserData?> GetUserFullData(Expression<Func<ApplicationUserData, bool>>? expression = null);
}
