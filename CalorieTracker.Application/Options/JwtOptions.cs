namespace CalorieTracker.Application.Options;

public class JwtOptions
{
    public int ExpirationTimeInMinutes { get; set; }
    public required string Audience { get; set; }
    public required string Issuer { get; set; }
    public required string Secret { get; init; } 
}