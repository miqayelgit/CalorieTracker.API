using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;
using System.IdentityModel.Tokens.Jwt;

namespace CalorieTracker.Application.Contracts.Services.User;

public interface IApplicationUserService
{
    public Task RegisterAsync(RegistrationDto dto);
    public Task<GetApplicationUserDto> GetProfileByIdAsync(Guid id);
    public Task UpdateUser(Guid userId, UpdateUserDto dto);
}