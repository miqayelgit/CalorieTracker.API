using CalorieTracker.API.Attributes;
using CalorieTracker.API.Filters;
using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

[CustomAuth]
[ServiceFilter(typeof(AuthorizationFilter))]
[ApiController]
[Route("api/[controller]")]
public class ActivityGoalsController : ControllerBase
{
    private readonly IActivityLevelService _activityLevelService;
    private readonly IFitnessGoalService _fitnessGoalService;

    public ActivityGoalsController(IActivityLevelService activityLevelService, IFitnessGoalService fitnessGoalService)
    {
        _activityLevelService = activityLevelService;
        _fitnessGoalService = fitnessGoalService;
    }

    [HttpGet("activity-levels")]
    public async Task<IActionResult> GetActivityLevels()
    {
        var levels =  await _activityLevelService.GetActivityLevelsAsync();
        return Ok(levels);
    }

    [HttpGet("fitness-goals")]
    public async Task<IActionResult> GetFitnessGoals()
    {
        var levels = await _fitnessGoalService.GetFitnessGoalsAsync();
        return Ok(levels);
    }
}
