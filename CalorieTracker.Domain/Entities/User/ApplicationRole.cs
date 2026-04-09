using CalorieTracker.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ICollection<AplicationUserRole> UserRoles { get; set; } = [];
    }
}
