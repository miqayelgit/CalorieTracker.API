using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.Seed;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Services.Seed;

public class ApplicationRoleSeedService : IApplicationRoleSeedService
{
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationRoleSeedService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task SeedAsync()
    {
        var roles = await _unitOfWork.RoleRepository.GetFromWhereAsync();
        var newRoles = GetRoles()
            .Where(x => !roles.Any(r => r.Name!.Equals(x)))
            .ToList();

        if (newRoles.Count == 0)
        {
            return;
        }

        var entities = newRoles
            .Select(roleName => new ApplicationRole
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
       
        _unitOfWork.RoleRepository.AddRange(entities);
        await _unitOfWork.CommitAsync();
    }

    private static string[] GetRoles()
    {
        return Enum.GetValues(typeof(Role))
            .Cast<Role>()
            .Select(x => x.ToString())
            .ToArray();
    }
}
