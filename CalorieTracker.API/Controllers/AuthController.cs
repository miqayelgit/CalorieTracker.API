using CalorieTracker.API.Attributes;
using CalorieTracker.API.Mappers;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost]
    [Route("sign-in")]
    public async Task<IActionResult> SignIn([FromBody]SignInDto dto)
    {
        try
        {
            var user = await _authenticationService.SignInUser(dto);
            return Ok(user);
        }
        catch (CustomException ex)
        {
            return ExceptionMapper.MapException(ex, this);
        }
    }

    [HttpPost]
    [Route("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        try
        {
            string token = await _authenticationService.ForgotPassword(dto);
            return Ok(token);

        }
        catch (CustomException ex)
        {
            return ExceptionMapper.MapException(ex, this);
        }
    }

    [HttpPost]
    [Route("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
    {
        try
        {
           await _authenticationService.ResetPassword(dto);
           return Ok();
        }
        catch (CustomException ex)
        {
           return ExceptionMapper.MapException(ex, this);
        }
    }
}
