

namespace CalorieTracker.Dtos.Users;

public class ResetPasswordDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
    public required string NewPassword { get; set; }
}
