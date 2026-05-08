using CalorieTracker.API.Attributes;
using CalorieTracker.API.Filters;
using CalorieTracker.API.Helpers;
using CalorieTracker.API.Mappers;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CalorieTracker.API.Controllers;

[CustomAuth]
[ServiceFilter(typeof(AuthorizationFilter))]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService;

    public UsersController(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto request)
    {
        var token = Request.Headers.Authorization.FirstOrDefault();

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized();
        }

        await _applicationUserService.RegisterAsync(request);
        return Ok();
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetUserProfile()
    {
        try
        {
           
            var jwtToken = TokenHelper.ReadJwtToken(HttpContext);

            if (jwtToken == null)
            {
                return BadRequest("Invalid token");
            }

            var user = await _applicationUserService.GetUserByToken(jwtToken);
            return Ok(user);

        }
        catch (CustomException ex)
        {
           return ExceptionMapper.MapException(ex, this);
        }

    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
    {
        try
        {
            var jwtToken = TokenHelper.ReadJwtToken(HttpContext);

            if (jwtToken == null)
            {
                return BadRequest("Invalid token");
            }

            await _applicationUserService.UpdateUser(dto, jwtToken);
            return Ok();

        }
        catch (CustomException ex)
        {
            return ExceptionMapper.MapException(ex, this);
        }

    }
} 