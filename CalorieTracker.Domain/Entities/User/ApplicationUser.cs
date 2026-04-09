using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Domain.Entities.DailyLimits;
using CalorieTracker.Domain.Entities.Product;
using CalorieTracker.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public ICollection<AplicationUserRole> UserRoles { get; set; } = [];
    public ICollection<DailyCalorieLimit> DailyCalorieLimits { get; set; } = [];
    public ICollection<DailyNutrientsIntakeAmount> DailyNutrientsIntakeAmounts { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
    public ApplicationUserData UserData { get; set; } = null!;
}
