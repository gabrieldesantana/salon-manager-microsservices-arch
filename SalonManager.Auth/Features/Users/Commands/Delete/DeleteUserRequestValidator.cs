using FluentValidation;

namespace SalonManager.Auth.Features.Users.Commands.Delete
{
    public sealed class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserRequestValidator()
        {
            RuleFor(validation => validation.Id)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
