using AngularWebApi.ApplicationCore.Models.Options;

namespace AngularWebApi.Server.Extensions.Configurations;

public static class OptionsConfiguration
{
    public static void ConfigureOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<ApplicationOptions>()
            .Bind(builder.Configuration)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services.AddOptions<RateLimitOptions>()
            .Bind(builder.Configuration.GetSection(RateLimitOptions.Section))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}