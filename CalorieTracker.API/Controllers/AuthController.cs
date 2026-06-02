using CalorieTracker.API.Middlewares;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Dtos.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IValidator<SignInDto> _signInDtovalidator;
    private readonly IValidator<ForgotPasswordDto> _forgotPasswordDtoValidator;
    private readonly IValidator<ResetPasswordDto> _resetPasswordDtoValidator;

    public AuthController(IAuthenticationService authenticationService, IValidator<SignInDto> validator, IValidator<ForgotPasswordDto> forgotPasswordDtoValidator, IValidator<ResetPasswordDto> resetPasswordDtoValidator)
    {
        _authenticationService = authenticationService;
        _signInDtovalidator = validator;
        _forgotPasswordDtoValidator = forgotPasswordDtoValidator;
        _resetPasswordDtoValidator = resetPasswordDtoValidator;
    }

    [Authorize]
    [HttpGet("auth-check")]
    public IActionResult CheckAuth()
    {
        return Ok(UserId);
    }
    
    [HttpPost]
    [Route("sign-in")]
    public async Task<IActionResult> SignIn([FromBody]SignInDto dto)
    {
        //await _signInDtovalidator.ValidateAndThrowAsync(dto);

        var user = await _authenticationService.SignInUser(dto);
        return Ok(user);
    }

    [HttpPost]
    [Route("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
       await _forgotPasswordDtoValidator.ValidateAndThrowAsync(dto);

       string token = await _authenticationService.ForgotPassword(dto);
       return Ok(token);

    }

    [HttpPost]
    [Route("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
    {
       await _resetPasswordDtoValidator.ValidateAndThrowAsync(dto);

       await _authenticationService.ResetPassword(dto);
       return Ok();
    }
}
