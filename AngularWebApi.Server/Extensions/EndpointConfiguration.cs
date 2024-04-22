using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Interfaces;
using AngularWebApi.Server.Validators;
using AutoMapper;

namespace AngularWebApi.Server.Extensions;

public static class EndpointConfiguration
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        app.MapPost("/api/v1/user/registration", async (RegistrationRequest req, IRepository repo) =>
        {
            var result = await new RegistrationValidator().ValidateAsync(req);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return Results.BadRequest(new { Message = string.Join(" ", errors) });
            }

            repo.RegisterUser(req);
            await repo.SaveAsync();

            return Results.NoContent();
        }).WithName("UserRegistration").WithOpenApi();

        app.MapGet("/api/v1/country", async (IRepository repo, IMapper mapper) =>
        {
            var items = await repo.GetCountriesAsync();
            return TypedResults.Ok(mapper.Map<List<CountryDto>>(items));
        }).WithName("GetCountries").WithOpenApi();

        app.MapGet("/api/v1/country/{id:int}/provinces", async (int id, IRepository repo, IMapper mapper) =>
        {
            var items = await repo.GetProvincesByCountryAsync(id);
            return TypedResults.Ok(mapper.Map<List<ProvinceDto>>(items));
        }).WithName("GetProvinces").WithOpenApi();
    }
}