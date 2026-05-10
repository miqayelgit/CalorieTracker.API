using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.User;

namespace CalorieTracker.Application.Services.User;

public class ApplicationRoleService : IApplicationRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationRoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
