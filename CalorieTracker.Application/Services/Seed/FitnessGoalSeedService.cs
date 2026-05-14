using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.Seed;
using CalorieTracker.Domain.Entities.ActivityGoals;

namespace CalorieTracker.Application.Services.Seed;

public class FitnessGoalSeedService : IFitnessGoalSeedService
{
    private readonly IUnitOfWork _unitOfWork;

    public FitnessGoalSeedService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task SeedAsync()
    {
        if(await _unitOfWork.FitnessGoalRepository.AnyAsync())
        {
            return;
        }

        var entities = MacroPercentages
            .Select(macro => new FitnessGoal
            {
                GoalName = macro.Name,
                ProteinPercent = macro.Protein,
                CarbsPercent = macro.Carbs,
                FatPercent = macro.Fat,
                AdditionalCalories = macro.AdditionalCalories
            });

        _unitOfWork.FitnessGoalRepository.AddRange(entities);
        await _unitOfWork.CommitAsync();
        
    } 


    public static readonly List<(string Name,byte Protein, byte Carbs, byte Fat, short AdditionalCalories)> MacroPercentages = new()
    {
        ( "Lose Weight",40, 30, 30, -500),
        ( "Maintain",   30, 40, 30, 0),
        ( "Gain Weight", 30, 50, 20, 500)
    };
}
