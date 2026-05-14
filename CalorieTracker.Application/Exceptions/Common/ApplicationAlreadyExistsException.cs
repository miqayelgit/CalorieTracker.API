using CalorieTracker.Application.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace CalorieTracker.Application.Exceptions.Common;

public class ApplicationAlreadyExistsException : BaseApplicationException
{
    public override int ErrorCode => StatusCodes.Status409Conflict;

    public ApplicationAlreadyExistsException(string message, Exception? exception = null) : base(message, exception)
    {
    }
}