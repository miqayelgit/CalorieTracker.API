
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Contracts.Services.Calculators;

public interface IUserDataCalculators
{
    Task CalculateUserDailyCalorieLimitsAsync(ApplicationUserData userData);
    Task CalculateFoodIntake(UserIntakeRecordDto dto, Guid userId);
}
