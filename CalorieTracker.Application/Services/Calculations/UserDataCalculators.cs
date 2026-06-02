
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Exceptions.Common;
using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.UserDataCalculation;
using CalorieTracker.Dtos.Users;
using System.Net.Http.Json;

namespace CalorieTracker.Application.Services.Calculations;

public class UserDataCalculators
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Guid _userId;
    private static readonly HttpClient _client = new();
    public UserDataCalculators(IUnitOfWork unitOfWork, Guid userId)
    {
        _unitOfWork = unitOfWork;
        _userId = userId;
    }
    public async Task CalculateUserDailyCalorieLimitsAsync(ApplicationUserData userData)
    {
        var activityLevel = await _unitOfWork.ActivityLevelRepository.FirstOrDefaultAsync(x => x.Id == userData.ActivityLevelId);

        var fitnessGoal = await _unitOfWork.FitnessGoalRepository.FirstOrDefaultAsync(x => x.Id == userData.FitnessGoalId);

        var requestBody = new CalculateUserDataDto
        {
            ActivityLevelRate = activityLevel!.ActivityLevelRate,
            AdditionalCalories = fitnessGoal!.AdditionalCalories,
            Age = userData.Age,
            Gender = userData.Gender,
            Height = userData.Height,
            Weight = userData.Weight,
            ProteinPercent = fitnessGoal.ProteinPercent,
            CarbsPercent = fitnessGoal.CarbsPercent,
            FatPercent = fitnessGoal.FatPercent
        };

        var response = await _client.PostAsJsonAsync("https://localhost:7223/CalculateUserData", requestBody);

        var calculationResults = await response.Content.ReadFromJsonAsync<CalculationResultsDto>();

        
        var dailyLimitOfCalories = new DailyCalorieLimit
        {
            UserId = _userId,
            DailyLimit = calculationResults.DailyCalorieLimit,
            UsedLimit = 0,
            RemainingLimit = 0,
            CreatedAt = DateTime.UtcNow
        };

        var dailyNutrientsIntake = new DailyNutrientsIntakeAmount
        {
            UserId = _userId,
            Protein = calculationResults.DailyProteinAmount,
            Carbs = calculationResults.DailyCarbsAmount,
            Fat = calculationResults.DailyFatAmount,
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
