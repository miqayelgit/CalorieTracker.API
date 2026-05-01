namespace CalorieTracker.Application.Exceptions;

public class InvalidInputException : CustomException
{
    public InvalidInputException(string? message) : base(message)
    {
        ErrorCode = 400;
    }
}
