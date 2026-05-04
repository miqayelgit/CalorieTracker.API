using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;
using System.IdentityModel.Tokens.Jwt;

namespace CalorieTracker.Application.Contracts.Services.User;

public interface IApplicationUserService
{
    public Task RegisterAsync(RegistrationDto dto);

    public Task<GetApplicationUserDto> GetUserByToken(JwtSecurityToken token);
    public Task UpdateUser(UpdateUserDto dto, JwtSecurityToken token);
}