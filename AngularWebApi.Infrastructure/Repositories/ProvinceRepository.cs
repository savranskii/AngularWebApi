using AngularWebApi.Domain.UserAggregate.Entities;
using AngularWebApi.Domain.UserAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AngularWebApi.Infrastructure.Repositories;

public class ProvinceRepository(ApplicationDbContext context) : IProvinceRepository
{
    public async Task<List<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken)
    {
        return await context.Provinces.Where(p => p.CountryId == countryId).ToListAsync(cancellationToken);
    }
}