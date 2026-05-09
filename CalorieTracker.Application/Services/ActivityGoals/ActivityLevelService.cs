using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Domain.Entities.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace CalorieTracker.Application.Contracts.Services.ActivityGoals;

public class ActivityLevelService : IActivityLevelService
{
    private readonly IUnitOfWork _unitOfWork;

    public ActivityLevelService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task SeedAsync()
    {
       var levels = await _unitOfWork.ActivityLevelRepository.FirstOrDefaultAsync();

        if (levels != null)
        {
            return;
        }

        foreach (var level in ActivityLevels)
        {
            var activityLevel = new ActivityLevel
            {
                ActivityLevelName = level.Key,
                ActivityLevelRate = level.Value
            };

            _unitOfWork.ActivityLevelRepository.Add(activityLevel);
        }

        await _unitOfWork.CommitAsync();
    }

    public async Task<List<ActivityLevelDto>> GetActivityLevelsAsync()
    {

        List<ActivityLevelDto> activityLevelsList = new List<ActivityLevelDto>();
        
        var levels =  await _unitOfWork.ActivityLevelRepository.GetFromWhereAsync();

        if(levels == null)

        {
            return activityLevelsList;
        }

        foreach (var level in levels)
        {
            ActivityLevelDto dto = new ActivityLevelDto
            {
                Id = level.Id,
                ActivityLevelName = level.ActivityLevelName
            };

            activityLevelsList.Add(dto);
        }

        return activityLevelsList;
    }


    public readonly Dictionary<string, float> ActivityLevels = new()
    {
        { "Sedentary", 1.2f },
        { "Lightly Active", 1.375f },
        { "Moderately Active", 1.55f },
        { "Very Active", 1.725f },
        { "Extra Active", 1.9f }
    };
}
