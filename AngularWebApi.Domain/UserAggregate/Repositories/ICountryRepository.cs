using AngularWebApi.Domain.UserAggregate.Entities;

namespace AngularWebApi.Domain.UserAggregate.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
}