using FluentValidation;

namespace SalonManager.Auth.Features.Users.Commands.Insert
{
    public sealed class InsertUserRequestValidator : AbstractValidator<InsertUserRequest>
    {
        public InsertUserRequestValidator()
        {
            RuleFor(validation => validation.FullName)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Login)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Email)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Password)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Role)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
