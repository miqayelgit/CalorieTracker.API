using CalorieTracker.Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.FitnessGoal;

public class FitnessGoalEntity
{
    public Guid Id { get; set; }
    public string GoalName { get; set; } = null!;
    public byte ProteinPercent { get; set; }
    public byte FatPercent { get; set; }
    public byte CarbsPercent { get; set; }
    public ICollection<ApplicationUserDataEntity> UserDatas { get; set; } = [];
}
