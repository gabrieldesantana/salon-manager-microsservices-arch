using FluentValidation;

namespace SalonManager.Auth.Features.Users.Commands.Update
{
    public sealed class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(validation => validation.Id)
              .NotEmpty()
              .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.FullName)
              .NotEmpty()
              .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Login)
              .NotEmpty()
              .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Email)
              .NotEmpty()
              .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
