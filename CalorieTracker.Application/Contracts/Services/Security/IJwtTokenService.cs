using CalorieTracker.Domain.Entities.User;
using System.Collections;

namespace CalorieTracker.Application.Contracts.Services.Security;

public interface IJwtTokenService
{
    string Generate(ApplicationUser user, IList<string> roles);
}