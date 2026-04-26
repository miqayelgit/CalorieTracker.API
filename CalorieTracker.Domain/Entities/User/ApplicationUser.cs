using CalorieTracker.Domain.Entities.DailyLimits;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Domain.Entities.User;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public ICollection<Product.Product> Products { get; set; } = [];
    public ApplicationUserData UserData { get; set; } = null!;
    public ICollection<ApplicationUserRole> UserRoles { get; set; } = [];
    public ICollection<DailyCalorieLimit> DailyCalorieLimits { get; set; } = [];
    public ICollection<DailyNutrientsIntakeAmount> DailyNutrientsIntakeAmounts { get; set; } = [];
}
