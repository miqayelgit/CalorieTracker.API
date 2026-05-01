using CalorieTracker.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Mappers;

public static class ExceptionMapper
{
    public static ObjectResult MapException(CustomException exception, ControllerBase controller)
    {
        switch (exception.ErrorCode)
        {
            case 404:
                return controller.NotFound(exception.Message);
            case 400:
                return controller.BadRequest(exception.Message);
            default:
                break;
        }

        return controller.Problem();
    }
}
