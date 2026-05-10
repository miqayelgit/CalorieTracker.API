using CalorieTracker.API.Helpers;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CalorieTracker.API.Controllers;

[Authorize]
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
        var user = await _applicationUserService.GetProfileByIdAsync(UserId);
        return Ok(user);


    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
    {


        await _applicationUserService.UpdateUser(dto);
        return Ok();

    }

    [HttpPost("user-data")]
    public async Task<IActionResult> FillApplicationUserData([FromBody] ApplicationUserDataDto dto)
    {
        await _applicationUserDataService.FillUserData(dto);
        return Ok();
    }

    //public async Task<IActionResult> GetUserData()
    //{
    //    await _applicationUserDataService.FillUserData(dto);
    //    return Ok();
    //}
} 