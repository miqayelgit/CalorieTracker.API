
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Services.Calculations;

public class UserDataCalculators
{
    private readonly IUnitOfWork _unitOfWork;

    public UserDataCalculators(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<short> CalculateUserDailyCalorieLimitsAsync(ApplicationUserDataDto dto)
    {
        var activityLevel = await _unitOfWork.ActivityLevelRepository.FirstOrDefaultAsync(x => x.Id == dto.ActivityLevelId);

        var decisive = dto.Gender == "Male" ? 5 : -161;

        var BMR = 10 * dto.Weight + 6.25 * dto.Height - 5 * dto.Age + decisive;

        var dailyCalorieLimit = BMR * activityLevel!.ActivityLevelRate;

        return (short)dailyCalorieLimit;
    }

    public async Task CalculateDailyNutirentsIntakeAmountsAsync()
    {

    }
}
