using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Exceptions;
using AngularWebApi.Infrastructure.Interfaces;
using AngularWebApi.Server.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AngularWebApi.Server.Endpoints;

public static class UserEndpoint
{
    public static async Task<NoContent> RegistrationAsync(RegistrationRequest req, IRepository repo)
    {
        await new RegistrationValidator().ValidateAndThrowAsync(req);

        if (await repo.IsUserExistAsync(req.Login))
            throw new UserAlreadyExistException($"User with login '{req.Login}' already exist.");

        repo.RegisterUser(req);
        await repo.SaveAsync();

        return TypedResults.NoContent();
    }
}
