using CalorieTracker.Application.Contracts.Services.Security;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Identity;


namespace CalorieTracker.Application.Services.User;

public class AuthenticationService : IAuthenticationService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthenticationService(
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager, 
        IJwtTokenService jwtTokenService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task<GetApplicationUserDto> SignInUser(SignInDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName);

        if (user == null)
        {
            throw new NotFoundException("User does not exist!"); 
        }

        var result =  await _signInManager
            .PasswordSignInAsync(dto.UserName, dto.Password, false, false);

        if (!result.Succeeded)
        {
            throw new InvalidInputException("Incorrect password!");
        }

        var token =  _jwtTokenService.Generate(user);
        
        return new GetApplicationUserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

    public async Task<string> ForgotPassword(ForgotPasswordDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user == null)
        {
            throw new NotFoundException("User not found!");
        }

        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task ResetPassword(ResetPasswordDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);
        if(user == null)
        {
            throw new NotFoundException("User not found!");
        }

        var identityResult = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);

        if (!identityResult.Succeeded)
        {
            throw new InvalidInputException("Unable to reset password");
        }
    }
}
