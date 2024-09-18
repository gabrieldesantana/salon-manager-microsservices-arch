using FluentValidation;

namespace SalonManager.Business.Features.SalonServices.Commands.Insert
{
    public sealed class InsertSalonServiceRequestValidator : AbstractValidator<InsertSalonServiceRequest>
    {
        public InsertSalonServiceRequestValidator()
        {
            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.UserCreatorId)
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
