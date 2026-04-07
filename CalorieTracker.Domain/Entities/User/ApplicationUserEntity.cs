using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User;

public class ApplicationUserEntity : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

}
