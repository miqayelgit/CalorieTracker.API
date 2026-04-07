using CalorieTracker.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities.User
{
    public class AplicationRoleEntity : IdentityRole<Guid>
    {
    }
}
