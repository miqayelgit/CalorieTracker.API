using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.User;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());

        ApplicationUserData user2 = new ApplicationUserData
        {
            Id = dto.UserId,
            ActivityLevelId = dto.ActivityLevelId,
            FitnessGoalId = dto.FitnessGoalId,
            Height = dto.Height,
            Weight = dto.Weight,
            Age = dto.Age
        };

        _unitOfWork.ApplicationUserDataRepository.Add(user2);
        await _unitOfWork.CommitAsync();
    }

    public Task<ApplicationUser> GetUserFullData()
    {
        throw new NotImplementedException();
    }
}
