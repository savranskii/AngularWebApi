using WebApi.Domain.UserAggregate.Entities;

namespace WebApi.Domain.UserAggregate.Repositories;

public interface IProvinceRepository
{
    Task<List<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken);
}