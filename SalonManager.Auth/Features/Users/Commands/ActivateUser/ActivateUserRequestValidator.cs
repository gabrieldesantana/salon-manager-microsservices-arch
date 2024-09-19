using FluentValidation;

namespace SalonManager.Auth.Features.Users.Commands.ActivateUser
{
    public sealed class ActivateUserRequestValidator : AbstractValidator<ActivateUserRequest>
    {
        public ActivateUserRequestValidator()
        {
            RuleFor(validation => validation.Id)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.FullName)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
