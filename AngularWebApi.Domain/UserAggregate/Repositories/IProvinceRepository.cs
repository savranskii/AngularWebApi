using AngularWebApi.Domain.Seeds;
using AngularWebApi.Domain.UserAggregate.Entities;

namespace AngularWebApi.Domain.UserAggregate.Repositories;

public interface IProvinceRepository
{
    IUnitOfWork UnitOfWork { get; }
    Task<List<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken);
}