using WebApi.Domain.Seeds;
using WebApi.Domain.UserAggregate.Repositories;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Repositories;

namespace WebApi.Server.Extensions.Configurations;

public static class DependencyConfiguration
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}