using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AngularWebApi.Server.Endpoints;

public static class CountryEndpoint
{
    public static Func<IRepository, IMapper, Task<Ok<List<CountryDto>>>> GetCountriesAsync()
    {
        return async (IRepository repo, IMapper mapper) =>
        {
            var items = await repo.GetCountriesAsync();
            return TypedResults.Ok(mapper.Map<List<CountryDto>>(items));
        };
    }

    public static Func<int, IRepository, IMapper, Task<Ok<List<ProvinceDto>>>> GetProvincesAsync()
    {
        return async (int id, IRepository repo, IMapper mapper) =>
        {
            var items = await repo.GetProvincesByCountryAsync(id);
            return TypedResults.Ok(mapper.Map<List<ProvinceDto>>(items));
        };
    }
}
