namespace CalorieTracker.Dtos.Users;

public class UpdateUserDto
{
    public string  Id { get; set; }
    public required string FirstName { get; set; } 
    public  required string LastName { get; set; }
    public  required string Email { get; set; }
}