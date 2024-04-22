using AngularWebApi.Server.ExceptionHandlers;

namespace AngularWebApi.Server.Extensions;

public static class ExceptionHandlerConfiguration
{
    public static void ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<DefaultExceptionHandler>();
    }
}