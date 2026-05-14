using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Contracts.Services.User;

public interface IApplicationUserDataService
{
    Task FillUserData(Guid userId, ApplicationUserDataDto dto);
    public Task<UserFullDataDto> GetUserFullData(Guid userId);

}
