using FluentValidation;

namespace SalonManager.Auth.Features.Users.Queries.Select
{
    public sealed class SelectUserRequestValidator : AbstractValidator<SelectUserRequest>
    {
        public SelectUserRequestValidator()
        {
            RuleFor(validation => validation.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
