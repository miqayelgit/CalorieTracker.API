using Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.DailyLimits;

public class DailyNutrientsIntakeAmount
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public short Protein { get; set; }
    public short Fat { get; set; }
    public short Carbs { get; set; }
    public ApplicationUser? User { get; set; } = null!;
}
