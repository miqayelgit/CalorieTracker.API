using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Contracts.Services.User_Records;

public interface IRecordFoodIntake
{
    public Task Record(Guid userId, UserIntakeRecordDto dto);
}
