using CalorieTracker.Application.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace CalorieTracker.Application.Exceptions.Common;

public class ApplicationNotFoundException : BaseApplicationException
{
    public override int ErrorCode => StatusCodes.Status404NotFound;

    public ApplicationNotFoundException(string message, Exception? exception = null) : base(message, exception)
    {
    }
}