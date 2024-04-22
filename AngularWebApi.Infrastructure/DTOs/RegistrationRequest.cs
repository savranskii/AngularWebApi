namespace AngularWebApi.Infrastructure.DTOs;

public record RegistrationRequest(
    string Login,
    string Password,
    bool IsAgreeToWorkForFood,
    int Country,
    int Province);