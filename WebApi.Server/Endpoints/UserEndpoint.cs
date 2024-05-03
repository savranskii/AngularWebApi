using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Domain.Seeds;
using WebApi.Server.Validators;
using WebApi.Shared.DTOs;
using WebApi.Shared.Exceptions;

namespace WebApi.Server.Endpoints;

public static class UserEndpoint
{
    public static async Task<NoContent> RegistrationAsync(RegistrationRequest req, IUnitOfWork unitOfWork,
        CancellationToken cancellationToken)
    {
        await new RegistrationValidator().ValidateAndThrowAsync(req, cancellationToken);

        if (await unitOfWork.UserRepository.IsUserExistAsync(req.Login))
            throw new UserAlreadyExistException($"User with login '{req.Login}' already exist.");

        unitOfWork.UserRepository.RegisterUser(req.Login, req.Password, req.IsAgreeToWorkForFood, req.Country,
            req.Province);
        await unitOfWork.SaveEntitiesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}