using FluentValidation;

namespace SalonManager.Business.Features.SalonServices.Queries.SelectAll
{
    public sealed class SelectAllSalonServicesRequestValidator : AbstractValidator<SelectAllSalonServicesRequest>
    {
        public SelectAllSalonServicesRequestValidator()
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
