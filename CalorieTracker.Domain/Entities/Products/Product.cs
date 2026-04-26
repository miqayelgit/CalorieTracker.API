

using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Entities.Product;

public class Product
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string ProductName { get; set; } = null!;
    public float ProteinPerHundredGram { get; set; }
    public float FatPerHundredGram { get; set; }
    public float CarbsPerHundredGram { get; set; }
    public short CaloriesPerHundredGram { get; set; }
    public VisibilityScope VisibilityScope { get; set; }
    public ApplicationUser? User { get; set; }
}
