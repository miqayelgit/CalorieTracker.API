using CalorieTracker.Application.Contracts.Services.Security;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
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
            throw new NotFoundException("User does not exist!"); 
        }

        var result =  await _signInManager
            .PasswordSignInAsync(dto.UserName, dto.Password, false, false);

        if (!result.Succeeded)
        {
            throw new InvalidInputException("Incorrect password!");
        }

        var token =  _jwtTokenService.Generate(user);
        
        return new SignInResponseDto
        {
           Token = token
        };
    }

    //return token in response + 
    //What is middleware + read filter
    //create get profile endpoint. User should not send anything. Only for authorized users+
    //read what means useAutorization middleware+
    //add endpoints. Change user related data+
    //after this read how allow only authorized users to access endpoint+
    //read about JWT - didn't but l +
    //create project like this for Admin with different methods. Not methods +-
    //role based authorization -
    //add endpoint to add user data - 
    //


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
