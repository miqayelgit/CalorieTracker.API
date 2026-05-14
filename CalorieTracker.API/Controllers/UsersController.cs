using CalorieTracker.API.Helpers;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CalorieTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private readonly IApplicationUserService _applicationUserService;
    private readonly IApplicationUserDataService _applicationUserDataService;

    public UsersController(IApplicationUserService applicationUserService, IApplicationUserDataService applicationUserDataService)
    {
        _applicationUserService = applicationUserService;
        _applicationUserDataService = applicationUserDataService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto request)
    {
        await _applicationUserService.RegisterAsync(request);
        return Ok();
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetUserProfile()
    {
        var user = await _applicationUserService.GetProfileByIdAsync(UserId);
        return Ok(user);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
    {
       await _applicationUserService.UpdateUser(dto);
       return Ok();
    }

    [Authorize]
    [HttpPost("user-data")]
    public async Task<IActionResult> FillApplicationUserData([FromBody] ApplicationUserDataDto dto)
    {
        await _applicationUserDataService.FillUserData(UserId, dto);
        return Ok();
    }

    [Authorize]
    [HttpGet("user-data")]
    public async Task<IActionResult> GetUserData()
    {
        var userData = await _applicationUserDataService.GetUserFullData(UserId);
        return Ok(userData);
    }
}