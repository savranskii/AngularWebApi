using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Interfaces;
using AngularWebApi.Server.Validators;
using FluentValidation;

namespace AngularWebApi.Server.Endpoints;

public static class UserEndpoint
{
    public static Func<RegistrationRequest, IRepository, Task<IResult>> RegistrationAsync()
    {
        return async (RegistrationRequest req, IRepository repo) =>
        {
            await new RegistrationValidator().ValidateAndThrowAsync(req);

            repo.RegisterUser(req);
            await repo.SaveAsync();

            return Results.NoContent();
        };
    }
}
