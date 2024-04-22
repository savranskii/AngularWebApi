namespace AngularWebApi.Infrastructure.Options;

public class RateLimitOptions
{
    public const string FixedPolicy = "fixed";
    public const string Section = "RateLimit";
    
    public int PermitLimit { get; set; }
    public int Window { get; set; }
    public int QueueLimit { get; set; }
}