using FluentValidation;

namespace SalonManager.Business.Features.Employees.Queries.Select
{
    public sealed class SelectEmployeeRequestValidator : AbstractValidator<SelectEmployeeRequest>
    {
        public SelectEmployeeRequestValidator()
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
