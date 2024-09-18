using FluentValidation;

namespace SalonManager.Business.Features.Companies.Commands.Delete
{
    public sealed class DeleteCompanyRequestValidator : AbstractValidator<DeleteCompanyRequest>
    {
        public DeleteCompanyRequestValidator()
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
