
using Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.DailyCalorieLimit;

public class DailyCalorieLimitEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public short DailyLimit { get; set; }
    public short UsedLimit { get; set; }
    public short RemainingLimit { get; set; }
    public DateTime CreatedDate { get; set; }
    public ApplicationUserEntity User { get; set; } = null!;
}
