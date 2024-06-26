﻿using FluentValidation;
using WebApi.Shared.DTOs;

namespace WebApi.Server.Validators;

public class RegistrationValidator : AbstractValidator<RegistrationRequest>
{
    public RegistrationValidator()
    {
        RuleFor(x => x.Login).NotNull().EmailAddress();
        RuleFor(x => x.Password).Matches("^(?=.*[A-Za-z])(?=.*\\d).+$");
        RuleFor(x => x.IsAgreeToWorkForFood).Must(v => v);
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.Province).NotEmpty();
    }
}