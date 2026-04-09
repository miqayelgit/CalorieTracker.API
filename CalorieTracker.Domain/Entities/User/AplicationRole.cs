using CalorieTracker.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class AplicationRole : IdentityRole<Guid>
    {
        public ICollection<AplicationUserRole> UserRoles { get; set; } = [];
    }
}
