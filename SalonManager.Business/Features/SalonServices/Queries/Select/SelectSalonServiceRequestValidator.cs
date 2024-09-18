using FluentValidation;

namespace SalonManager.Business.Features.SalonServices.Queries.Select
{
    public sealed class SelectSalonServiceRequestValidator : AbstractValidator<SelectSalonServiceRequest>
    {
        public SelectSalonServiceRequestValidator()
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
