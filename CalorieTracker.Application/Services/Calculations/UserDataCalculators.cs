using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.Calculators;
using CalorieTracker.Application.Exceptions.Common;
using CalorieTracker.Application.HttpClientService;
using CalorieTracker.Application.Options.ApiClient;
using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.UserDataCalculation;
using CalorieTracker.Dtos.Users;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace CalorieTracker.Application.Services.Calculations;

public class UserDataCalculators : IUserDataCalculators
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApiClient _apiClient;
    private readonly UserDatCalculatorServiceOptions _userDatCalculatorServiceOptions;

    public UserDataCalculators(IUnitOfWork unitOfWork, ApiClient apiClient, IOptions<UserDatCalculatorServiceOptions> userDatCalculatorServiceOptions)
    {
        _unitOfWork = unitOfWork;
        _apiClient = apiClient;
        _userDatCalculatorServiceOptions = userDatCalculatorServiceOptions.Value;
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


        var uri = $"{_userDatCalculatorServiceOptions.BaseUri}{_userDatCalculatorServiceOptions.Path}";

        var response = await _apiClient.Post(JsonSerializer.Serialize(requestBody), uri);

        var calculationResults = await response.Content.ReadFromJsonAsync<CalculationResultsDto>();

        
        var dailyLimitOfCalories = new DailyCalorieLimit
        {
            UserId = userData.Id,
            DailyLimit = calculationResults!.DailyCalorieLimit,
            UsedLimit = 0,
            RemainingLimit = 0,
            CreatedAt = DateTime.UtcNow
        };

        var dailyNutrientsIntake = new DailyNutrientsIntakeAmount
        {
            UserId = userData.Id,
            Protein = calculationResults.DailyProteinAmount,
            Carbs = calculationResults.DailyCarbsAmount,
            Fat = calculationResults.DailyFatAmount,
            CreatedAt = DateTime.UtcNow
        };


        _unitOfWork.DailyCalorieLimitRepository.Add(dailyLimitOfCalories);
        _unitOfWork.DailyNutrientsIntakeAmountRepository.Add(dailyNutrientsIntake);

        await _unitOfWork.CommitAsync();
    }

    public async Task CalculateFoodIntake(UserIntakeRecordDto dto, Guid userId)
    {
        var product = await _unitOfWork.ProductRepository.FirstOrDefaultAsync(x => x.Id == dto.ProductId);
        var calorieLimits = await _unitOfWork.DailyCalorieLimitRepository.FirstOrDefaultAsync(x => x.UserId == userId);
        var nutrientsLimits = await _unitOfWork.DailyNutrientsIntakeAmountRepository.FirstOrDefaultAsync(x => x.UserId == userId);

        if (product == null || calorieLimits == null || nutrientsLimits == null)
        {
            throw new ApplicationNotFoundException("Product or Daily limit or Nutirent limits Not Found");
        }

        float foodUnit = dto.FoodAmountInGrams / 100;

        nutrientsLimits.Protein = (short)(nutrientsLimits.Protein - foodUnit * product.ProteinPerHundredGram);
        nutrientsLimits.Fat = (short)(nutrientsLimits.Fat - foodUnit * product.FatPerHundredGram);
        nutrientsLimits.Carbs = (short)(nutrientsLimits.Carbs - foodUnit * product.CarbsPerHundredGram);
        nutrientsLimits.UpdatedAt = DateTime.UtcNow;


        var usedLimit = (short)(foodUnit * product.CaloriesPerHundredGram + calorieLimits.UsedLimit);
        calorieLimits.UsedLimit = usedLimit;
        calorieLimits.RemainingLimit = (short)(calorieLimits.DailyLimit - usedLimit);
        calorieLimits.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.DailyNutrientsIntakeAmountRepository.Update(nutrientsLimits);
        _unitOfWork.DailyCalorieLimitRepository.Update(calorieLimits);
    }
}
