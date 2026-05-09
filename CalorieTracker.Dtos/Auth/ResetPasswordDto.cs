namespace CalorieTracker.Dtos.Auth;

public class ResetPasswordDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
    public required string NewPassword { get; set; }
}
