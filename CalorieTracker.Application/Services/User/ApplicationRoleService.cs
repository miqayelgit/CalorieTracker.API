using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Domain.Entities.User;

namespace CalorieTracker.Application.Services.User;

public class ApplicationRoleService : IApplicationRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationRoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SeedAsync()
    {
        var roles = await _unitOfWork.RoleRepository.GetFromWhereAsync();
        var newRoles = Roles
            .Where(x => !roles.Any(r => r.Name!.Equals(x)))
            .ToList();

        if (newRoles.Count == 0)
        {
            return;
        }
        
        newRoles.ForEach(roleName =>
        {
            var newRole = new ApplicationRole
            {
                Name = roleName
            };
            
            _unitOfWork.RoleRepository.Add(newRole);
        });
        
        await  _unitOfWork.CommitAsync();
    }

    private static string[] Roles => ["User"];
}
