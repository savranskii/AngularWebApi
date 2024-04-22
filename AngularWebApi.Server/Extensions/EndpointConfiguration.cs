using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Interfaces;

namespace AngularWebApi.Server.Extensions;

public static class EndpointConfiguration
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        app.MapPost("/api/v1/user/registration", async (RegistrationRequest req, IRepository repo) =>
        {
            repo.RegisterUser(req);
            await repo.SaveAsync();

            return TypedResults.NoContent();
        }).WithName("UserRegistration").WithOpenApi();

        app.MapGet("/api/v1/country", async (IRepository repo) =>
        {
            var items = await repo.GetCountriesAsync();
            return TypedResults.Ok(items);
        }).WithName("GetCountries").WithOpenApi();

        app.MapGet("/api/v1/country/{id:int}/provinces", async (int id, IRepository repo) =>
        {
            var items = await repo.GetProvincesByCountryAsync(id);
            return TypedResults.Ok(items);
        }).WithName("GetProvinces").WithOpenApi();
    }
}
