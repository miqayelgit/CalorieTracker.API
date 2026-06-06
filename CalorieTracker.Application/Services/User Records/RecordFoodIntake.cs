
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.Calculators;
using CalorieTracker.Application.Contracts.Services.User_Records;
using CalorieTracker.Application.Services.Calculations;
using CalorieTracker.Dtos.Users;

namespace CalorieTracker.Application.Services.User_Records;

public class RecordFoodIntake : IRecordFoodIntake
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDataCalculators _userDataCalculators;

    public RecordFoodIntake(IUnitOfWork unitOfWork, IUserDataCalculators userDataCalculators)
    {
        _unitOfWork = unitOfWork;
        _userDataCalculators = userDataCalculators;
    }

    public async Task Record(Guid userId, UserIntakeRecordDto dto)
    {
        await _userDataCalculators.CalculateFoodIntake(dto, userId);
        await _unitOfWork.CommitAsync();
    }
}
