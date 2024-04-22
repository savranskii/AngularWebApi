using AngularWebApi.Server.Endpoints;
using FluentValidation;

namespace AngularWebApi.Server.Extensions.Configurations;

public static class EndpointConfiguration
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        app.MapPost("/api/v1/user/registration", UserEndpoint.RegistrationAsync())
            .WithName("UserRegistration")
            .WithOpenApi();

        app.MapGet("/api/v1/country", CountryEndpoint.GetCountriesAsync())
            .WithName("GetCountries")
            .WithOpenApi();

        app.MapGet("/api/v1/country/{id:int}/provinces", CountryEndpoint.GetProvincesAsync())
            .WithName("GetProvinces")
            .WithOpenApi();
    }
}