using AngularWebApi.Infrastructure.Interfaces;
using AngularWebApi.Infrastructure.Repositories;

namespace AngularWebApi.Server.Extensions.Configurations;

public static class DependencyConfiguration
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IRepository, ApplicationRepository>();
    }
}