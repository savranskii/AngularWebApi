namespace AngularWebApi.Server.Extensions.Configurations;

public static class CorsConfiguration
{
    public const string PolicyName = "_ui";

    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(o => o.AddPolicy(PolicyName, c => c
            .WithOrigins("https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));
    }
}