using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.ActivityGoals;
using CalorieTracker.Domain.Entities.ActivityGoals;
using CalorieTracker.Dtos.ActivityGoals;

namespace CalorieTracker.Application.Services.ActivityGoals;

public class FitnessGoalService : IFitnessGoalService
{
    private readonly IUnitOfWork _unitOfWork;

    public FitnessGoalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SeedAsync()
    {
        var goals = await _unitOfWork.FitnessGoalRepository.FirstOrDefaultAsync();

        if(goals == null)
        {
            foreach(var goal in MacroPercentages)
            {
                var activityGoal = new FitnessGoal
                {
                    GoalName = goal.Key,
                    ProteinPercent = goal.Value.Protein,
                    CarbsPercent = goal.Value.Carbs,
                    FatPercent = goal.Value.Fat
                };

                _unitOfWork.FitnessGoalRepository.Add(activityGoal);
            }

            await _unitOfWork.CommitAsync();
        }
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

    public static readonly Dictionary<string, (byte Protein, byte Carbs, byte Fat)> MacroPercentages = new()
    {
        { "Lose Weight", (40, 30, 30) },
        { "Maintain",   (30, 40, 30) },
        { "Gain Weight", (30, 50, 20) }
    };
}
