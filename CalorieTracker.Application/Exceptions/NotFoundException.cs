namespace CalorieTracker.Application.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string? message) : base(message)
        {
            ErrorCode = 404;
        }

    }
}