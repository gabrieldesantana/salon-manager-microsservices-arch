using FluentValidation;

namespace SalonManager.Customers.Features.Customers.Queries.SelectAll
{
    public sealed class SelectAllCustomersRequestValidator : AbstractValidator<SelectAllCustomersRequest>
    {
        public SelectAllCustomersRequestValidator()
        {
            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PageNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PageSize)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
