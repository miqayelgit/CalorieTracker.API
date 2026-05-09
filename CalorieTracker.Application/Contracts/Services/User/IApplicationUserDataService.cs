using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Contracts.Services.User;

public interface IApplicationUserDataService
{
    Task FillUserData(ApplicationUserDataDto dto);
    public Task<ApplicationUser> GetUserFullData();

}
