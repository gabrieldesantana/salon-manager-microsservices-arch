using FluentValidation;

namespace SalonManager.Business.Features.SalonServices.Commands.Update
{
    public sealed class UpdateSalonServiceRequestValidator : AbstractValidator<UpdateSalonServiceRequest>
    {
        public UpdateSalonServiceRequestValidator()
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

            RuleFor(validation => validation.Category)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Price)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
