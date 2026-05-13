using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityGoalsController : ControllerBase
{
    private readonly IActivityLevelService _activityLevelService;
    private readonly IFitnessGoalService _fitnessGoalService;
    private readonly ILogger<ActivityGoalsController> _logger;

    public ActivityGoalsController(IActivityLevelService activityLevelService, IFitnessGoalService fitnessGoalService, ILogger<ActivityGoalsController> logger)
    {
        _activityLevelService = activityLevelService;
        _fitnessGoalService = fitnessGoalService;
        _logger = logger;
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
