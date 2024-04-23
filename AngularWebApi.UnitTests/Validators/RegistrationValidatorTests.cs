using AngularWebApi.ApplicationCore.Models.DTOs;
using AngularWebApi.Server.Validators;

namespace AngularWebApi.UnitTests.Validators;

public class RegistrationValidatorTests
{
    [Fact]
    public void ValidateFullModel_ReturnValid()
    {
        // Arrange
        var data = new RegistrationRequest("test@mail.com", "123ert", true, 1, 1);

        // Act
        var result = new RegistrationValidator().Validate(data);
        
        // Assert
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("test@mail.com", "aaaaaa", true)]
    [InlineData("testmail.com", "aaa111", true)]
    [InlineData("testmail.com", "123456", false)]
    public void ValidateInvalidModel_ReturnValid(string email, string password, bool isAgreeToWorkForFood)
    {
        // Arrange
        var data = new RegistrationRequest(email, password, isAgreeToWorkForFood, 1, 1);

        // Act
        var result = new RegistrationValidator().Validate(data);

        // Assert
        Assert.False(result.IsValid);
    }
}
