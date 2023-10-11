using Authentication.Service.DTOs.Auth;
using FluentValidation;

namespace Authentication.Service.Validators.Dtos.Auth;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(dto => dto.Email).Must(phone => EmailValidator.IsValid(phone))
            .WithMessage("Email is invalid! EX: someone@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
