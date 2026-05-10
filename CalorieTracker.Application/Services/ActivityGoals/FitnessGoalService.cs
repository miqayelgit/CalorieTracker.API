using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;

namespace CalorieTracker.Application.Services.ActivityGoals;

public class FitnessGoalService : IFitnessGoalService
{
    private readonly IUnitOfWork _unitOfWork;

    public FitnessGoalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<FitnessGoalDto>> GetFitnessGoalsAsync()
    {
        List<FitnessGoalDto> goalsList = new List<FitnessGoalDto>();

        var registeredGoals =  await _unitOfWork.FitnessGoalRepository.GetFromWhereAsync();

        foreach(var goal in registeredGoals)
        {
            var dto = new FitnessGoalDto
            {
                Id = goal.Id,
                GoalName = goal.GoalName,
                ProteinPercent = goal.ProteinPercent,
                CarbsPercent = goal.CarbsPercent,
                FatPercent = goal.FatPercent
            };

            goalsList.Add(dto);
        }

        return goalsList;
    }
}
