using FluentValidation;
using SalonManager.Customers.CrossCutting.Validations;

namespace SalonManager.Customers.Features.Customers.Commands.Insert
{
    public sealed class InsertCustomerRequestValidator : AbstractValidator<InsertCustomerRequest>
    {
        public InsertCustomerRequestValidator()
        {
            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.UserCreatorId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Cpf)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado")
                .Must(RegexValidation.ValidaCpf!)
                .WithMessage("CPF invalido. Exemplo: 123.456.789-12");

            RuleFor(validation => validation.FullName)
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
