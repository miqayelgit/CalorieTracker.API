using CalorieTracker.Application.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace CalorieTracker.Application.Exceptions.Users;

public class IncorrectUserCredentialsException : BaseApplicationException
{
    public override int ErrorCode => StatusCodes.Status401Unauthorized;

    public IncorrectUserCredentialsException(string message, Exception? exception = null) : base(message, exception)
    {
    }
}
