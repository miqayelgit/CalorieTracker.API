using CalorieTracker.Application.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace CalorieTracker.Application.Exceptions.Users;


public class IncorrectUserDataException : BaseApplicationException
{
    public override int ErrorCode => StatusCodes.Status400BadRequest;
    public IncorrectUserDataException(string message, Exception? exception = null) : base(message, exception)
    {
    }
}
