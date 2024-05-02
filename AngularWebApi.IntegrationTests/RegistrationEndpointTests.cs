using System.Net;
using System.Text;
using System.Text.Json;
using AngularWebApi.Application.DTOs;
using AngularWebApi.Domain.UserAggregate.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AngularWebApi.IntegrationTests;

public class RegistrationEndpointTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private static int _index = 1;
    
    [Theory]
    [InlineData("/api/v1/user/registration")]
    public async Task Post_Registration_EndpointReturnNoContent(string url)
    {
        // Arrange
        using var scope = factory.Server.Services.GetService<IServiceScopeFactory>()!.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var client = factory.CreateClient();

        var login = $"test{_index++}@mail.com";
        
        var data = new RegistrationRequest(login, "123rtd", true, 1, 1);
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(url, content);
        var isExist = await repo.IsUserExistAsync(login);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.True(isExist);
    }

    [Theory]
    [InlineData("/api/v1/user/registration")]
    public async Task Post_RegistrationWithMissingFields_EndpointReturnBadRequestAndCorrectContentType(string url)
    {
        // Arrange
        var client = factory.CreateClient();
        var data = new RegistrationRequest($"test{_index++}@mail.com", string.Empty, true, 1, 1);
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
        var email = $"test{_index++}@mail.com";
        var data = new RegistrationRequest(email, "123ert", true, 1, 1);
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        // Act
        _ = await client.PostAsync(url, content);
        var response = await client.PostAsync(url, content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}