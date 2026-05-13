using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions.Users;
using CalorieTracker.Application.Services.Calculations;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Application.Services.User;

public class ApplicationUserDataService : IApplicationUserDataService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserDataService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task FillUserData(ApplicationUserDataDto dto)
    {
        if(!Genders.Contains(dto.Gender))
        {
            throw new IncorrectUserDataException("Gender possible values are: Male, Female");
        }

        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());

        ApplicationUserData user2 = new ApplicationUserData
        {
            Id = dto.UserId,
            ActivityLevelId = dto.ActivityLevelId,
            FitnessGoalId = dto.FitnessGoalId,
            Height = dto.Height,
            Weight = dto.Weight,
            Age = dto.Age,
            Gender = dto.Gender
        };

        _unitOfWork.ApplicationUserDataRepository.Add(user2);

        var calculators = new UserDataCalculators(_unitOfWork);

        var dailyCalorieLimit = await calculators
            .CalculateUserDailyCalorieLimitsAsync(dto);

        await _unitOfWork.CommitAsync();
    }

    public Task<ApplicationUser> GetUserFullData()
    {
        throw new NotImplementedException();
    }

    private static List<string> Genders = ["Male", "Female"];
}
