
using CalorieTracker.Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.Activity_Level;

public class ActivityLevelEntity
{
    public Guid Id { get; set; }
    public string ActivityLevelName { get; set; } = null!;
    public float ActivityLevelRate { get; set; }
    public ICollection<ApplicationUserDataEntity> UserDatas { get; set; } = [];
}
