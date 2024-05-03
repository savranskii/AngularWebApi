using Microsoft.EntityFrameworkCore;
using WebApi.Domain.UserAggregate.Entities;
using WebApi.Domain.UserAggregate.Repositories;

namespace WebApi.Infrastructure.Repositories;

public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        return await context.Countries.ToListAsync(cancellationToken);
    }
}