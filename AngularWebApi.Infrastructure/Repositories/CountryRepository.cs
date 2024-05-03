﻿using Microsoft.EntityFrameworkCore;
using AngularWebApi.Domain.UserAggregate.Entities;
using AngularWebApi.Domain.UserAggregate.Repositories;

namespace AngularWebApi.Infrastructure.Repositories;

public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        return await context.Countries.ToListAsync(cancellationToken);
    }
}