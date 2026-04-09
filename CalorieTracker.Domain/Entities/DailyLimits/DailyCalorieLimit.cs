
using Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.DailyLimits;

public class DailyCalorieLimit
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public short DailyLimit { get; set; }
    public short UsedLimit { get; set; }
    public short RemainingLimit { get; set; }
    public DateTime CreatedDate { get; set; }
    public ApplicationUser? User { get; set; }
}
