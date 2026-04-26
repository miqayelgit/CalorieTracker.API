using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Domain.Entities.User;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser User { get; set; } = null!;
    public ApplicationRole Role{ get; set; } = null!;
}
