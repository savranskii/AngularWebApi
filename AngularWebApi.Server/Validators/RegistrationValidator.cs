using AngularWebApi.ApplicationCore.Models.DTOs;
using FluentValidation;

namespace AngularWebApi.Server.Validators;

public class RegistrationValidator : AbstractValidator<RegistrationRequest>
{
    public RegistrationValidator()
    {
        RuleFor(x => x.Login).NotNull().EmailAddress();
        RuleFor(x => x.Password).Matches("^(?:[0-9]+[a-z]|[a-z]+[0-9])[a-z0-9]*$");
        RuleFor(x => x.IsAgreeToWorkForFood).Must(v => v);
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.Province).NotEmpty();
    }
}