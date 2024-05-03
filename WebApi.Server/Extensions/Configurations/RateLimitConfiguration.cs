using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using WebApi.Shared.Configurations;

namespace WebApi.Server.Extensions.Configurations;

public static class RateLimitConfiguration
{
    public static void ConfigureRateLimit(this WebApplicationBuilder builder)
    {
        var config = new RateLimitOptions();
        builder.Configuration.GetSection(RateLimitOptions.Section).Bind(config);

        builder.Services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            options.AddFixedWindowLimiter(RateLimitOptions.FixedPolicy, o =>
            {
                o.PermitLimit = config.PermitLimit;
                o.Window = TimeSpan.FromSeconds(config.Window);
                o.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                o.QueueLimit = config.QueueLimit;
            });
        });
    }
}