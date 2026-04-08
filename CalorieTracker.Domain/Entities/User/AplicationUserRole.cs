using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Domain.Entities.User;

public class AplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser User { get; set; } = null!;
    public AplicationRole Role{ get; set; } = null!;
}
