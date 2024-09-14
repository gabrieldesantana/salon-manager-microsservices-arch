using FluentValidation;

namespace SalonManager.Customers.Features.Customers.Queries.Select
{
    public sealed class SelectCustomerRequestValidator : AbstractValidator<SelectCustomerRequest>
    {
        public SelectCustomerRequestValidator()
        {
            RuleFor(validation => validation.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.TenantId)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado");
        }

    }
}
