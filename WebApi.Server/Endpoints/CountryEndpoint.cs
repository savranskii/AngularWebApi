﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Domain.Seeds;
using WebApi.Shared.DTOs;

namespace WebApi.Server.Endpoints;

public static class CountryEndpoint
{
    public static async Task<Ok<List<CountryDto>>> GetCountriesAsync(IUnitOfWork unitOfWork, IMapper mapper,
        CancellationToken cancellationToken)
    {
        var items = await unitOfWork.CountryRepository.GetCountriesAsync(cancellationToken);
        return TypedResults.Ok(mapper.Map<List<CountryDto>>(items));
    }

    public static async Task<Ok<List<ProvinceDto>>> GetProvincesAsync(int id, IUnitOfWork unitOfWork, IMapper mapper,
        CancellationToken cancellationToken)
    {
        var items = await unitOfWork.ProvinceRepository.GetProvincesByCountryAsync(id, cancellationToken);
        return TypedResults.Ok(mapper.Map<List<ProvinceDto>>(items));
    }
}