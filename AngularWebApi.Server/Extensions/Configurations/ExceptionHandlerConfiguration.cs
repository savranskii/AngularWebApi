using AngularWebApi.Server.ExceptionHandlers;

namespace AngularWebApi.Server.Extensions.Configurations;

public static class ExceptionHandlerConfiguration
{
    public static void ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<DefaultExceptionHandler>();
    }
}