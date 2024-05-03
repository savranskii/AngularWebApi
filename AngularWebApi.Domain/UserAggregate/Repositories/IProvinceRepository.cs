using AngularWebApi.Domain.UserAggregate.Entities;

namespace AngularWebApi.Domain.UserAggregate.Repositories;

public interface IProvinceRepository
{
    Task<List<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken);
}