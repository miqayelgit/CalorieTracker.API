using CalorieTracker.Domain.Entities.User;

namespace CalorieTracker.Application.Contracts.Services.Security;

public interface IJwtTokenService
{
    string Generate(ApplicationUser user);
}