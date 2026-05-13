using CalorieTracker.API.Controllers;
using CalorieTracker.Application.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace CalorieTracker.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex, _logger);
        }
    }

    private static Task HandleException(HttpContext context, Exception exception, ILogger<ExceptionHandlingMiddleware> _logger)
    {
        return exception switch
        {
            BaseApplicationException applicationException =>
                HandleApplicationExceptions(context, applicationException, _logger),

            _ =>
                HandleInternalServerExceptions(context, exception, _logger)
        };
    }

    private static async Task HandleApplicationExceptions(HttpContext context, BaseApplicationException exception, ILogger<ExceptionHandlingMiddleware> _logger)
    {
        var statusCode = exception.ErrorCode;
        var message = exception.Message;

        _logger.LogError(message);

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(
            new ErrorResponse { Error = message });
    }

    private static async Task HandleInternalServerExceptions(HttpContext context, Exception exception, ILogger<ExceptionHandlingMiddleware> _logger)
    {
        // TODO :: Log real exception message exception.Message
        _logger.LogError(exception.Message);

        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { error = "Please try again later" });
    }
}

public class ErrorResponse
{
    public string? Error { get; set; }
}
