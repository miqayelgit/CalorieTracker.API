
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Exceptions.Common;
using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Domain.Entities.User;
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
    public async Task CalculateUserDailyCalorieLimitsAsync(ApplicationUserData userData)
    {
        var activityLevel = await _unitOfWork.ActivityLevelRepository.FirstOrDefaultAsync(x => x.Id == userData.ActivityLevelId);

        var fitnessGoal = await _unitOfWork.FitnessGoalRepository.FirstOrDefaultAsync(x => x.Id == userData.FitnessGoalId);

        var decisive = userData.Gender == "Male" ? 5 : -161;

        var BMR = 10 * userData.Weight + 6.25 * userData.Height - 5 * userData.Age + decisive + fitnessGoal!.AdditionalCalories;

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
            CreatedAt = DateTime.UtcNow
        };

        var dailyNutrientsIntake = new DailyNutrientsIntakeAmount
        {
            UserId = _userId,
            Protein = dailyProteinAmount,
            Carbs = dailyCarbsAmount,
            Fat = dailyFatAmount,
            CreatedAt = DateTime.UtcNow
        };

        _unitOfWork.DailyCalorieLimitRepository.Add(dailyLimitOfCalories);
        _unitOfWork.DailyNutrientsIntakeAmountRepository.Add(dailyNutrientsIntake);
    }

    public async Task CalculateFoodIntake(UserIntakeRecordDto dto)
    {
        var product = await _unitOfWork.ProductRepository.FirstOrDefaultAsync(x => x.Id == dto.ProductId);
        var calorieLimits = await _unitOfWork.DailyCalorieLimitRepository.FirstOrDefaultAsync(x => x.UserId == _userId);
        var nutrientsLimits = await _unitOfWork.DailyNutrientsIntakeAmountRepository.FirstOrDefaultAsync(x => x.UserId == _userId);

        if (product == null || calorieLimits == null || nutrientsLimits == null)
        {
            throw new ApplicationNotFoundException("Product or Daily limit or Nutirent limits Not Found");
        }

        float foodUnit = dto.FoodAmountInGrams / 100;

        nutrientsLimits.Protein = (short) (nutrientsLimits.Protein - foodUnit * product.ProteinPerHundredGram);
        nutrientsLimits.Fat = (short)(nutrientsLimits.Fat - foodUnit * product.FatPerHundredGram);
        nutrientsLimits.Carbs = (short) (nutrientsLimits.Carbs - foodUnit * product.CarbsPerHundredGram);
        nutrientsLimits.UpdatedAt = DateTime.UtcNow;
        

        var usedLimit = (short)(foodUnit * product.CaloriesPerHundredGram + calorieLimits.UsedLimit);
        calorieLimits.UsedLimit = usedLimit;
        calorieLimits.RemainingLimit= (short)(calorieLimits.DailyLimit - usedLimit);
        calorieLimits.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.DailyNutrientsIntakeAmountRepository.Update(nutrientsLimits);
        _unitOfWork.DailyCalorieLimitRepository.Update(calorieLimits);
    }
}
