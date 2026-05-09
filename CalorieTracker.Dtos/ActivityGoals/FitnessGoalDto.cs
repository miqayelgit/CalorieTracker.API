
namespace CalorieTracker.Dtos.ActivityGoals;

public class FitnessGoalDto
{
    public Guid Id { get; set; }
    public string GoalName { get; set; } = null!;
    public byte ProteinPercent { get; set; }
    public byte FatPercent { get; set; }
    public byte CarbsPercent { get; set; }
}
