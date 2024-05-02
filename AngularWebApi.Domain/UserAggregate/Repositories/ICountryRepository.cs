using AngularWebApi.Domain.Seeds;
using AngularWebApi.Domain.UserAggregate.Entities;

namespace AngularWebApi.Domain.UserAggregate.Repositories;

public interface ICountryRepository
{
    IUnitOfWork UnitOfWork { get; }
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
}