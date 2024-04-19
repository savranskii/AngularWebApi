namespace AngularWebApi.Server.Extensions;

public static class CorsConfiguration
{
    public const string PolicyName = "_ui";

    public static void AddCorsConfig(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddCors(o => o.AddPolicy(PolicyName, c => c
            .WithOrigins("https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));
    }
}
