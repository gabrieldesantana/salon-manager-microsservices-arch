using FluentValidation;

namespace SalonManager.Customers.Features.Customers.Commands.Update
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(validation => validation.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Cpf)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Nickname)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Gender)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.BirthDate)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PhoneNumber)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
