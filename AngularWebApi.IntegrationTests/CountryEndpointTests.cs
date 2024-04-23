using AngularWebApi.ApplicationCore.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace AngularWebApi.IntegrationTests;

public class CountryEndpointTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/api/v1/country")]
    public async Task Get_CountryList_EndpointReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }

    [Theory]
    [InlineData("/api/v1/country/{0}/provinces", 1)]
    public async Task Get_ProvinceListByCountryId_EndpointReturnSuccessAndCorrectContentType(string url, int countryId)
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(string.Format(url, countryId));

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var result = await response.Content.ReadFromJsonAsync<List<ProvinceDto>>();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        Assert.True(result?.Count > 0);
    }

    [Theory]
    [InlineData("/api/v1/country/{0}/provinces", 0)]
    public async Task Get_ProvinceListByInvalidCountryId_EndpointReturnSuccessAndCorrectContentType(string url, int countryId)
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(string.Format(url, countryId));

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var result = await response.Content.ReadFromJsonAsync<List<ProvinceDto>>();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        Assert.True(result?.Count == 0);
    }
}