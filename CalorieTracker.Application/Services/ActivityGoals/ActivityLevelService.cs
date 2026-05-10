using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;

namespace CalorieTracker.Application.Services.ActivityGoals;

public class ActivityLevelService : IActivityLevelService
{
    private readonly IUnitOfWork _unitOfWork;

    public ActivityLevelService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    

    public async Task<List<ActivityLevelDto>> GetActivityLevelsAsync()
    {
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