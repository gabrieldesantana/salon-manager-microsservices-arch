using FluentValidation;

namespace SalonManager.Customers.Features.Customers.Commands.IncreaseVisitedTimes
{
    public sealed class IncreaseVisitedTimesRequestValidator : AbstractValidator<IncreaseVisitedTimesRequest>
    {
        public IncreaseVisitedTimesRequestValidator()
        {
            RuleFor(validation => validation.Id)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.LastServiceDate)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.LastServiceName)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
