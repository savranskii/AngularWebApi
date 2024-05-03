using WebApi.Domain.UserAggregate.Entities;

namespace WebApi.Domain.UserAggregate.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
}