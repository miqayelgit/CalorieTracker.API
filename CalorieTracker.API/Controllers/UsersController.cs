using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Dtos.Users;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private readonly IApplicationUserService _applicationUserService;
    private readonly IApplicationUserDataService _applicationUserDataService;
    private readonly IValidator<RegistrationDto> _registrationDtoValidator;
    private readonly IValidator<UpdateUserDto> _updateUserDtoValidator;
    private readonly IValidator<ApplicationUserDataDto> _applicationUserDataDtoValidator;

    public UsersController(
        IApplicationUserService applicationUserService,
        IApplicationUserDataService applicationUserDataService, 
        IValidator<RegistrationDto> registrationDtoValidator, 
        IValidator<UpdateUserDto> updateUserDtoValidator, 
        IValidator<ApplicationUserDataDto> applicationUserDataDtoValidator)
    {
        _applicationUserService = applicationUserService;
        _applicationUserDataService = applicationUserDataService;
        _registrationDtoValidator = registrationDtoValidator;
        _updateUserDtoValidator = updateUserDtoValidator;
        _applicationUserDataDtoValidator = applicationUserDataDtoValidator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto dto)
    {
        await _registrationDtoValidator.ValidateAndThrowAsync(dto);

        await _applicationUserService.RegisterAsync(dto);
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
       await _updateUserDtoValidator.ValidateAndThrowAsync(dto);

       await _applicationUserService.UpdateUser(UserId, dto);
       return Ok();
    }

    [Authorize]
    [HttpPost("user-data")]
    public async Task<IActionResult> FillApplicationUserData([FromBody] ApplicationUserDataDto dto)
    {
        await _applicationUserDataDtoValidator.ValidateAndThrowAsync(dto);

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