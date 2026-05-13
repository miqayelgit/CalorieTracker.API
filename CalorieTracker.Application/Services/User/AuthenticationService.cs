using CalorieTracker.Application.Contracts.Services.Security;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
using CalorieTracker.Application.Exceptions.Common;
using CalorieTracker.Application.Exceptions.Users;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Auth;
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
    
    public async Task<SignInResponseDto> SignInUser(SignInDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName);

        if (user == null)
        {
            throw new IncorrectUserCredentialsException("Incorrect credentials");
        }

        var roles = await _userManager.GetRolesAsync(user);

        var isCorrectPassword = await _userManager
            .CheckPasswordAsync(user, dto.Password);

        if (!isCorrectPassword)
        {
            throw new IncorrectUserCredentialsException("Incorrect credentials");
        }

        var token =  _jwtTokenService.Generate(user, roles);
        
        return new SignInResponseDto
        {
           Token = token
            // TODO : Add refresh token
        };
    }

    public async Task<string> ForgotPassword(ForgotPasswordDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user == null)
        {
            throw new ApplicationNotFoundException("User not found!");
        }

        // TODO : Send token to user email
        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task ResetPassword(ResetPasswordDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);

        if(user == null)
        {
            throw new ApplicationNotFoundException("User not found!");
        }

        var identityResult = await _userManager
            .ResetPasswordAsync(user, dto.Token, dto.NewPassword);

        if (!identityResult.Succeeded)
        {
            throw new IncorrectUserCredentialsException("Unable to reset password");
        }
    }
}
