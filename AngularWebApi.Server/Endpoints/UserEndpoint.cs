using AngularWebApi.Application.DTOs;
using AngularWebApi.Application.Exceptions;
using AngularWebApi.Domain.UserAggregate.Repositories;
using AngularWebApi.Server.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AngularWebApi.Server.Endpoints;

public static class UserEndpoint
{
    public static async Task<NoContent> RegistrationAsync(RegistrationRequest req, IUserRepository repo,
        CancellationToken cancellationToken)
    {
        await new RegistrationValidator().ValidateAndThrowAsync(req, cancellationToken);

        if (await repo.IsUserExistAsync(req.Login))
            throw new UserAlreadyExistException($"User with login '{req.Login}' already exist.");

        repo.RegisterUser(req.Login, req.Password, req.IsAgreeToWorkForFood, req.Country, req.Province);
        await repo.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}