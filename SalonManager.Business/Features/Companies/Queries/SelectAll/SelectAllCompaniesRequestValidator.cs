using FluentValidation;

namespace SalonManager.Business.Features.Companies.Queries.SelectAll
{
    public sealed class SelectAllCompaniesRequestValidator : AbstractValidator<SelectAllCompaniesRequest>
    {
        public SelectAllCompaniesRequestValidator()
        {
            RuleFor(validation => validation.PageNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PageSize)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
