using AngularWebApi.Domain.UserAggregate.Repositories;
using AngularWebApi.Infrastructure.Repositories;

namespace AngularWebApi.Server.Extensions.Configurations;

public static class DependencyConfiguration
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
    }
}