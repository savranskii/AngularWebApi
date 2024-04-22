using AngularWebApi.Server.Endpoints;
using FluentValidation;

namespace AngularWebApi.Server.Extensions.Configurations;

public static class EndpointConfiguration
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        app.MapPost("/api/v1/user/registration", UserEndpoint.RegistrationAsync)
            .WithName("UserRegistration")
            .WithOpenApi();

        app.MapGroup("/api/v1/country").MapCountryApi();
    }

    public static RouteGroupBuilder MapCountryApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", CountryEndpoint.GetCountriesAsync)
            .WithName("GetCountries")
            .WithOpenApi();

        group.MapGet("/{id:int}/provinces", CountryEndpoint.GetProvincesAsync)
            .WithName("GetProvinces")
            .WithOpenApi();

        return group;
    }
}