namespace CalorieTracker.Application.Exceptions
{
    public class CustomException : Exception
    {
        public int ErrorCode { get; set; }  
        public CustomException(string? message) : base(message) 
        {
        }
    }
}