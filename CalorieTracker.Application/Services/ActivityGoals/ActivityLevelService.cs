using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;
using Microsoft.Extensions.Logging;

namespace CalorieTracker.Application.Services.ActivityGoals;

public class ActivityLevelService : IActivityLevelService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ActivityLevelService> _logger;

    public ActivityLevelService(IUnitOfWork unitOfWork, ILogger<ActivityLevelService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    
    public async Task<List<ActivityLevelDto>> GetActivityLevelsAsync()
    {
        _logger.LogInformation("In Service");
        var entities = await _unitOfWork.ActivityLevelRepository
            .GetFromWhereAsync();
        
        return entities.Select(x => new ActivityLevelDto
            {
                Id = x.Id,
                Name = x.ActivityLevelName,
            })
            .ToList();
    }
}