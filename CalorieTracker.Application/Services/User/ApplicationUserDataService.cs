using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.Calculators;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Application.Exceptions.Common;
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
    private readonly IUserDataCalculators _userCalculators;

    public ApplicationUserDataService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IUserDataCalculators userCalculators)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _userCalculators = userCalculators;
    }

    public async Task FillUserData(Guid userId, ApplicationUserDataDto dto)
    {
        if(!Genders.Contains(dto.Gender.ToLower()))
        {
            throw new IncorrectUserDataException("Gender possible values are: Male, Female");
        }

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if(await _unitOfWork.ApplicationUserDataRepository.AnyAsync(x => x.Id == userId))
        {
            throw new ApplicationAlreadyExistsException("User Data already exists");
        }

        ApplicationUserData userData = new ApplicationUserData
        {
            Id = userId,
            ActivityLevelId = dto.ActivityLevelId,
            FitnessGoalId = dto.FitnessGoalId,
            Height = dto.Height,
            Weight = dto.Weight,
            Age = dto.Age,
            Gender = dto.Gender,
            CreatedAt = DateTime.UtcNow
        };

        _unitOfWork.ApplicationUserDataRepository.Add(userData);

        await _userCalculators.CalculateUserDailyCalorieLimitsAsync(userData);
    }

    public async Task<UserFullDataDto> GetUserFullData(Guid userId)
    {
        var user = await _unitOfWork.ApplicationUserDataRepository.GetUserFullData(x => x.Id == userId);

        if(user == null)
        {
            throw new ApplicationNotFoundException("User not found");
        }

        return new UserFullDataDto
        {
            Id = userId,
            FirstName = user.User!.FirstName,
            LastName = user.User.LastName,
            Email = user.User.Email,
            ActivityLevelId = user.ActivityLevelId,
            FitnessGoalId = user.FitnessGoalId,
            Height = user.Height,
            Weight = user.Weight,
            Age = user.Age,
            Gender = user.Gender
        };
    }

    private static List<string> Genders = ["male", "female"];
}
