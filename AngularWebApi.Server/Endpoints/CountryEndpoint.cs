using AngularWebApi.ApplicationCore.Interfaces;
using AngularWebApi.ApplicationCore.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AngularWebApi.Server.Endpoints;

public static class CountryEndpoint
{
    public static async Task<Ok<List<CountryDto>>> GetCountriesAsync(IRepository repo, IMapper mapper)
    {
        var items = await repo.GetCountriesAsync();
        return TypedResults.Ok(mapper.Map<List<CountryDto>>(items));
    }

    public static async Task<Ok<List<ProvinceDto>>> GetProvincesAsync(int id, IRepository repo, IMapper mapper)
    {
        var items = await repo.GetProvincesByCountryAsync(id);
        return TypedResults.Ok(mapper.Map<List<ProvinceDto>>(items));
    }
}
