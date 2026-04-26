using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Contracts.Services.User;

public interface IApplicationUserService
{
    Task RegisterAsync(RegistrationDto dto);
}