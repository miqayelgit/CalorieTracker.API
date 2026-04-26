using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Domain.Enums;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Application.Services.User;

public class ApplicationUserService : IApplicationUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task RegisterAsync(RegistrationDto dto)
    {
       var user = await _userManager.FindByNameAsync(dto.Email);

       if (user != null)
       {
           throw new Exception("User is already exists");
       }

       var newUser = new ApplicationUser
       {
           FirstName = dto.FirstName,
           LastName = dto.LastName,
           Email = dto.Email,
           UserName = dto.Email,
           CreatedAt =  DateTime.UtcNow
       };

       var identityResult = await _userManager
           .CreateAsync(newUser, dto.Password);

       if (!identityResult.Succeeded)
       {
           var errors = identityResult.Errors.Select(error => error.Description);
           throw new Exception($"Failed to create user : {string.Join(',', errors)}");
       }

       var roleIdentityResult = await _userManager.AddToRoleAsync(newUser, nameof(Role.User));

       if (!roleIdentityResult.Succeeded)
       {
           var errors = roleIdentityResult.Errors.Select(error => error.Description);
           throw new Exception($"Failed to create user : {string.Join(',', errors)}");
       }
    }
}
