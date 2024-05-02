using Microsoft.EntityFrameworkCore;
using AngularWebApi.Domain.Seeds;
using AngularWebApi.Domain.UserAggregate.Entities;
using AngularWebApi.Domain.UserAggregate.Repositories;

namespace AngularWebApi.Infrastructure.Repositories;

public class ProvinceRepository(ApplicationDbContext context) : IProvinceRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<List<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken)
    {
        return await context.Provinces.Where(p => p.CountryId == countryId).ToListAsync(cancellationToken);
    }
}