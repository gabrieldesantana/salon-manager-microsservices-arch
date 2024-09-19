using FluentValidation;
using SalonManager.Business.CrossCutting.Validations;

namespace SalonManager.Business.Features.Employees.Commands.Insert
{
    public sealed class InsertEmployeeRequestValidator : AbstractValidator<InsertEmployeeRequest>
    {
        public InsertEmployeeRequestValidator()
        {
            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.UserCreatorId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.UserId)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.CompanyId)
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
