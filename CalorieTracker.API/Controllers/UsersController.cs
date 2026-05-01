using CalorieTracker.API.Mappers;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

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
        await _applicationUserService.RegisterAsync(request);
        return Ok();
    }

    [HttpGet]
    [Route("get-by-username")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        try
        {
            var user = await _applicationUserService.GetUserByUsername(username);
            return Ok(user);

        }
        catch (CustomException ex)
        {
           return ExceptionMapper.MapException(ex, this);
        }

    }
} 