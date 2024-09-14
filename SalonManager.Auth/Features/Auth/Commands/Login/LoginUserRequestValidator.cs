using FluentValidation;

namespace SalonManager.Auth.Features.Auth.Commands.Login
{
    public sealed class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(validation => validation.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
