using System.Net.Http.Json;
using AngularWebApi.Application.DTOs;

namespace AngularWebApi.IntegrationTests;

public class CountryEndpointTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/api/v1/country")]
    public async Task Get_CountryList_EndpointReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);
        var result = await response.Content.ReadFromJsonAsync<List<CountryDto>>();

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        Assert.Equal(2, result?.Count);
        Assert.True(result?.Exists(c => c.Name == "Country 1"));
        Assert.True(result?.Exists(c => c.Name == "Country 2"));
    }

    [Theory]
    [InlineData("/api/v1/country/{0}/provinces", 1)]
    public async Task Get_ProvinceListByCountryId_EndpointReturnSuccessAndCorrectContentType(string url, int countryId)
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(string.Format(url, countryId));
        var result = await response.Content.ReadFromJsonAsync<List<ProvinceDto>>();

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        Assert.Equal(3, result?.Count);
        Assert.True(result?.Exists(c => c.Name == "Province 1.1"));
        Assert.True(result?.Exists(c => c.Name == "Province 1.2"));
        Assert.True(result?.Exists(c => c.Name == "Province 1.3"));
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
        Assert.Equal(0, result?.Count);
    }
}