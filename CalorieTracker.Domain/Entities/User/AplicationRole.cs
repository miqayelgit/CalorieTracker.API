using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities.User
{
    public class AplicationRole : IdentityRole<Guid>
    {
        public ICollection<AplicationUserRole> UserRoles { get; set; } = [];
    }
}
