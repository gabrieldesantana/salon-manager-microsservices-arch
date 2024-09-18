using FluentValidation;

namespace SalonManager.Business.Features.Employees.Commands.Delete
{
    public sealed class DeleteEmployeeRequestValidator : AbstractValidator<DeleteEmployeeRequest>
    {
        public DeleteEmployeeRequestValidator()
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
