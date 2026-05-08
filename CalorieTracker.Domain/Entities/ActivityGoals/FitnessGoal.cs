using CalorieTracker.Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.ActivityGoals;

public class FitnessGoal
{
    public Guid Id { get; set; }
    public string GoalName { get; set; } = null!;
    public byte ProteinPercent { get; set; }
    public byte FatPercent { get; set; }
    public byte CarbsPercent { get; set; }
    public ICollection<ApplicationUserData> UserDatas { get; set; } = [];
}
