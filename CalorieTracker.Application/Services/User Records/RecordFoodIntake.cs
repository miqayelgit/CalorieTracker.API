
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.User_Records;
using CalorieTracker.Application.Services.Calculations;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Services.User_Records;

public class RecordFoodIntake : IRecordFoodIntake
{
    private readonly IUnitOfWork _unitOfWork;

    public RecordFoodIntake(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Record(Guid userId, UserIntakeRecordDto dto)
    {
        var calculators = new UserDataCalculators(_unitOfWork, userId);
        
        await calculators.CalculateFoodIntake(dto);
        await _unitOfWork.CommitAsync();
    }
}
