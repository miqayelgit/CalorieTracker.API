
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Services.Calculations;

public class UserDataCalculators
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Guid _userId;
    public UserDataCalculators(IUnitOfWork unitOfWork, Guid userId)
    {
        _unitOfWork = unitOfWork;
        _userId = userId;
    }
    public async Task CalculateUserDailyCalorieLimitsAsync(ApplicationUserDataDto dto)
    {
        var activityLevel = await _unitOfWork.ActivityLevelRepository.FirstOrDefaultAsync(x => x.Id == dto.ActivityLevelId);

        var fitnessGoal = await _unitOfWork.FitnessGoalRepository.FirstOrDefaultAsync(x => x.Id == dto.FitnessGoalId);

        var decisive = dto.Gender == "Male" ? 5 : -161;

        var BMR = 10 * dto.Weight + 6.25 * dto.Height - 5 * dto.Age + decisive + fitnessGoal!.AdditionalCalories;

        var   dailyCalorieLimit = (short) (BMR * activityLevel!.ActivityLevelRate);
        short dailyProteinAmount = (short)(dailyCalorieLimit * fitnessGoal.ProteinPercent / 100 / 4);
        short dailyFatAmount = (short)(dailyCalorieLimit * fitnessGoal.FatPercent / 100 / 9);
        short dailyCarbsAmount = (short)(dailyCalorieLimit * fitnessGoal.CarbsPercent / 100 / 4);

        var dailyLimitOfCalories = new DailyCalorieLimit
        {
            UserId = _userId,
            DailyLimit = dailyCalorieLimit,
            UsedLimit = 0,
            RemainingLimit = 0,
            CreatedDate = DateTime.UtcNow.ToLocalTime()
        };

        var dailyNutrientsIntake = new DailyNutrientsIntakeAmount
        {
            UserId = _userId,
            Protein = dailyProteinAmount,
            Carbs = dailyCarbsAmount,
            Fat = dailyFatAmount
        };

        _unitOfWork.DailyCalorieLimitRepository.Add(dailyLimitOfCalories);
        _unitOfWork.DailyNutrientsIntakeAmountRepository.Add(dailyNutrientsIntake);
    }
}
