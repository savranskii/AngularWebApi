using Microsoft.EntityFrameworkCore;
using WebApi.Domain.UserAggregate.Entities;
using WebApi.Domain.UserAggregate.Repositories;

namespace WebApi.Infrastructure.Repositories;

public class ProvinceRepository(ApplicationDbContext context) : IProvinceRepository
{
    public async Task<List<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken)
    {
        return await context.Provinces.Where(p => p.CountryId == countryId).ToListAsync(cancellationToken);
    }
}