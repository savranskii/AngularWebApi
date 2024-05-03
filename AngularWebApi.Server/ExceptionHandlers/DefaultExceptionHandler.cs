using System.Net;
using AngularWebApi.Application.Exceptions;
using AngularWebApi.Application.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace AngularWebApi.Server.ExceptionHandlers;

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