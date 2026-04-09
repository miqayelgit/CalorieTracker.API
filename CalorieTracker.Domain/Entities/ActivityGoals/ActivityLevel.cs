
using CalorieTracker.Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.ActivityGoals;

public class ActivityLevel
{
    public Guid Id { get; set; }
    public string ActivityLevelName { get; set; } = null!;
    public float ActivityLevelRate { get; set; }
    public ICollection<ApplicationUserData> UserDatas { get; set; } = [];
}
