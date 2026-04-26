using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Domain.Entities.User;

public class ApplicationRole : IdentityRole<Guid>
{
    public ICollection<IdentityUserRole<Guid>> UserRoles { get; set; } = [];
}
