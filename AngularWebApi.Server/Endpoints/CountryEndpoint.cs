using AngularWebApi.Application.DTOs;
using AngularWebApi.Domain.UserAggregate.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AngularWebApi.Server.Endpoints;

public static class CountryEndpoint
{
    public static async Task<Ok<List<CountryDto>>> GetCountriesAsync(ICountryRepository repo, IMapper mapper,
        CancellationToken cancellationToken)
    {
        var items = await repo.GetCountriesAsync(cancellationToken);
        return TypedResults.Ok(mapper.Map<List<CountryDto>>(items));
    }

    public static async Task<Ok<List<ProvinceDto>>> GetProvincesAsync(int id, IProvinceRepository repo, IMapper mapper,
        CancellationToken cancellationToken)
    {
        var items = await repo.GetProvincesByCountryAsync(id, cancellationToken);
        return TypedResults.Ok(mapper.Map<List<ProvinceDto>>(items));
    }
}
