using FluentValidation;
using SalonManager.Business.CrossCutting.Validations;

namespace SalonManager.Business.Features.Companies.Commands.Update
{
    public sealed class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyRequest>
    {
        public UpdateCompanyRequestValidator()
        {
            RuleFor(validation => validation.Id)
               .NotEmpty()
               .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.CNPJ)
                .NotEmpty()
                    .WithMessage("{PropertyName} deve ser informado")
                .Must(RegexValidation.ValidaCNPJ!)
                    .WithMessage("CNPJ invalido. Exemplo: 00.000.000/0001-00");
        }
    }
}
