using CalorieTracker.Application.Contracts.Services.User;
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
} 