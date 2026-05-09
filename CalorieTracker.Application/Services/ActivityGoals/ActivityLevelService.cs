using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Domain.Entities.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;

namespace CalorieTracker.Application.Services.ActivityGoals;

public class ActivityLevelService : IActivityLevelService
{
    private readonly IUnitOfWork _unitOfWork;

    public ActivityLevelService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task SeedAsync()
    {
        if (await _unitOfWork.ActivityLevelRepository.AnyAsync())
        {
            return;
        }

        var entities = ActivityLevels
            .Select(x => new ActivityLevel
            {
                ActivityLevelName = x.Key,
                ActivityLevelRate = x.Value
            });
        
        _unitOfWork.ActivityLevelRepository.AddRange(entities);
        await _unitOfWork.CommitAsync();
        
        // foreach (var level in ActivityLevels)
        // {
        //     var activityLevel = new ActivityLevel
        //     {
        //         ActivityLevelName = level.Key,
        //         ActivityLevelRate = level.Value
        //     };
        //
        //     _unitOfWork.ActivityLevelRepository.Add(activityLevel);
        // }
        //
        // await _unitOfWork.CommitAsync();
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

    private static Dictionary<string, float> ActivityLevels => new()
    {
        { "Sedentary", 1.2f },
        { "Lightly Active", 1.375f },
        { "Moderately Active", 1.55f },
        { "Very Active", 1.725f },
        { "Extra Active", 1.9f },
    };
}