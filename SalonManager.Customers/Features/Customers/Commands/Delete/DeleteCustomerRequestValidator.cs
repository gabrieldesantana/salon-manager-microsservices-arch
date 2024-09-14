using FluentValidation;

namespace SalonManager.Customers.Features.Customers.Commands.Delete
{
    public sealed class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerRequestValidator()
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
