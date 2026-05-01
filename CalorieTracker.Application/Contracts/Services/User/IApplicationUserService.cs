using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Contracts.Services.User;

public interface IApplicationUserService
{
    public Task RegisterAsync(RegistrationDto dto);
    public Task<GetApplicationUserDto> GetUserByUsername(string username);
}