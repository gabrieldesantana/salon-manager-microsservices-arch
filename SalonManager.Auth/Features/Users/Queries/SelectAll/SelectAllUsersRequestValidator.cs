using FluentValidation;

namespace SalonManager.Auth.Features.Users.Queries.SelectAll
{
    public sealed class SelectAllUsersRequestValidator : AbstractValidator<SelectAllUsersRequest>
    {
        public SelectAllUsersRequestValidator()
        {
            RuleFor(validation => validation.PageNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PageSize)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
