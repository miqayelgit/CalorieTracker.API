namespace CalorieTracker.Dtos.Users;

public class UserFullDataDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public Guid ActivityLevelId { get; set; }
    public Guid FitnessGoalId { get; set; }
    public short Height { get; set; }
    public short Weight { get; set; }
    public byte Age { get; set; }
    public string Gender { get; set; } = null!;
}
