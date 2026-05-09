
namespace CalorieTracker.Dtos.Users;

public class ApplicationUserDataDto
{
    public Guid UserId { get; set; }
    public Guid ActivityLevelId { get; set; }
    public Guid FitnessGoalId { get; set; }
    public short Height { get; set; }
    public short Weight { get; set; }
    public byte Age { get; set; }
}
