using FluentValidation;

namespace SalonManager.Business.Features.Companies.Queries.Select
{
    public class SelectCompanyRequestValidator : AbstractValidator<SelectCompanyRequest>
    {
        public SelectCompanyRequestValidator()
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
