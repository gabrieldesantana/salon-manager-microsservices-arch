using FluentValidation;

namespace SalonManager.Business.Features.Employees.Queries.SelectAll
{
    public sealed class SelectAllEmployeesRequestValidator : AbstractValidator<SelectAllEmployeesRequest>
    {
        public SelectAllEmployeesRequestValidator()
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
