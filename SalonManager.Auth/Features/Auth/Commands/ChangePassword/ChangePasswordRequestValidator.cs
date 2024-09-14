using FluentValidation;

namespace SalonManager.Auth.Features.Auth.Commands.ChangePassword
{
    public sealed class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(validation => validation.OldPassword)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.NewPasswordOne)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.NewPasswordTwo)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation)
                .Must(validation => validation.NewPasswordOne == validation.NewPasswordTwo)
                .WithMessage("A senha e a confirmacao estao divergentes");
        }
    }
}
