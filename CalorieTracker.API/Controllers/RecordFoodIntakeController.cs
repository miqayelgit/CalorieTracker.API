using CalorieTracker.Application.Contracts.Services.User_Records;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RecordFoodIntakeController : BaseController
{
    private readonly IRecordFoodIntake _recordFoodIntake;

    public RecordFoodIntakeController(IRecordFoodIntake recordFoodIntake)
    {
        _recordFoodIntake = recordFoodIntake;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Record([FromBody] UserIntakeRecordDto dto)
    {
        await _recordFoodIntake.Record(UserId, dto);
        return Ok();
    }
}
