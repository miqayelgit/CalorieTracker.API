using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.Seed;
using CalorieTracker.Domain.Entities.ActivityGoals;

namespace CalorieTracker.Application.Services.Seed;

public class ActivityLevelSeedService : IActivityLevelSeedService
{
    private readonly IUnitOfWork _unitOfWork;

    public ActivityLevelSeedService(IUnitOfWork unitOfWork)
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
                ActivityLevelName = x.key,
                ActivityLevelRate = x.value
            });

        _unitOfWork.ActivityLevelRepository.AddRange(entities);
        await _unitOfWork.CommitAsync();
    }

    private static List<(string key, float value)> ActivityLevels => new()
  {
      ("Sedentary", 1.2f),
      ("Lightly Active", 1.375f),
      ("Moderately Active", 1.55f),
      ("Very Active", 1.725f),
      ("Extra Active", 1.9f)
  };
}
