namespace AngularWebApi.Server.Extensions.Configurations;

public static class CorsConfiguration
{
    public const string PolicyName = "_ui";

    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(o => o.AddPolicy(PolicyName, c => c
            .WithOrigins(builder.Configuration.GetValue<string>("Cors") ?? "*")
            .AllowAnyHeader()
            .AllowAnyMethod()));
    }
}