using CalorieTracker.Application.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace CalorieTracker.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private static Task HandleException(HttpContext context, Exception exception)
    {
        return exception switch
        {
            BaseApplicationException applicationException =>
                HandleApplicationExceptions(context, applicationException),

            _ =>
                HandleInternalServerExceptions(context, exception)
        };
    }

    private static async Task HandleApplicationExceptions(HttpContext context, BaseApplicationException exception)
    {
        var statusCode = exception.ErrorCode;
        var message = exception.Message;

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(
            new ErrorResponse { Error = message });
    }

    private static async Task HandleInternalServerExceptions(HttpContext context, Exception exception)
    {
        // TODO :: Log real exception message exception.Message

        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { error = "Please try again later" });
    }
}

public class ErrorResponse
{
    public string? Error { get; set; }
}
