using AngularWebApi.ApplicationCore.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;

namespace AngularWebApi.IntegrationTests;

public class RegistrationEndpointTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/api/v1/user/registration")]
    public async Task Post_Registration_EndpointReturnNoContent(string url)
    {
        // Arrange
        var client = factory.CreateClient();
        var data = new RegistrationRequest($"test{DateTime.UtcNow.Ticks}@mail.com", "123rtd", true, 1, 1);
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(url, content);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/v1/user/registration")]
    public async Task Post_RegistrationWithMissingFields_EndpointReturnBadRequestAndCorrectContentType(string url)
    {
        // Arrange
        var client = factory.CreateClient();
        var data = new RegistrationRequest($"test{DateTime.UtcNow.Ticks}@mail.com", string.Empty, true, 1, 1);
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(url, content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/v1/user/registration")]
    public async Task Post_RegistrationWithDuplicatedLogin_EndpointReturnBadRequestAndCorrectContentType(string url)
    {
        // Arrange
        var client = factory.CreateClient();
        var email = $"test{DateTime.UtcNow.Ticks}@mail.com";
        var data = new RegistrationRequest(email, "123ert", true, 1, 1);
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        // Act
        _ = await client.PostAsync(url, content);
        var response = await client.PostAsync(url, content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}