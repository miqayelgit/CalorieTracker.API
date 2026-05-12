namespace CalorieTracker.Application.Exceptions.Base;

public abstract class BaseApplicationException : Exception
{
    public abstract int ErrorCode { get; }

    protected BaseApplicationException()
    {
    }

    public BaseApplicationException(
        string? message, Exception? exception = null) : base(message, exception)
    {
    }
}