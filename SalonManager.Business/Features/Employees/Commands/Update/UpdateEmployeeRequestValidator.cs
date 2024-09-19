using FluentValidation;

namespace SalonManager.Business.Features.Employees.Commands.Update
{
    public sealed class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidator()
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
