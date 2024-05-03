using AngularWebApi.Domain.UserAggregate.Entities;
using AngularWebApi.Domain.UserAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AngularWebApi.Infrastructure.Repositories;

public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        return await context.Countries.ToListAsync(cancellationToken);
    }
}