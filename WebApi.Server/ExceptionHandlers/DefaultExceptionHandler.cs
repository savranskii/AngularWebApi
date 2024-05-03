using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using WebApi.Shared.Exceptions;
using WebApi.Shared.Models;

namespace WebApi.Server.ExceptionHandlers;

public class DefaultExceptionHandler(ILogger<DefaultExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An unexpected error occurred");

        var status = exception switch
        {
            UserAlreadyExistException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        httpContext.Response.StatusCode = (int)status;
        await httpContext.Response.WriteAsJsonAsync(new ErrorResponse(
            (int)status,
            "An unexpected error occurred",
            exception.Message,
            $"{httpContext.Request.Method} {httpContext.Request.Path}"
        ), cancellationToken);

        return true;
    }
}