using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using AngularWebApi.Application.Models;

namespace AngularWebApi.Server.ExceptionHandlers;

public class ValidationExceptionHandler(ILogger<DefaultExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "A validation error occurred");

        if (exception is not ValidationException) return false;

        var errors = ((ValidationException)exception).Errors.Select(e => e.ErrorMessage);

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await httpContext.Response.WriteAsJsonAsync(new ErrorResponse(
            (int)HttpStatusCode.BadRequest,
            "A validation error occurred",
            string.Join(" ", errors),
            $"{httpContext.Request.Method} {httpContext.Request.Path}"
        ), cancellationToken);
        return true;
    }
}