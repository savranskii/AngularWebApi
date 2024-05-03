using AngularWebApi.Domain.UserAggregate.Repositories;

namespace AngularWebApi.Domain.Seeds;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    ICountryRepository CountryRepository { get; }
    IProvinceRepository ProvinceRepository { get; }
    
    Task SaveEntitiesAsync(CancellationToken ct = default);
}