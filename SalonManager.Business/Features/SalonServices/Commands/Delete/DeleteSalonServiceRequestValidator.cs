using FluentValidation;

namespace SalonManager.Business.Features.SalonServices.Commands.Delete
{
    public sealed class DeleteSalonServiceRequestValidator : AbstractValidator<DeleteSalonServiceRequest>
    {
        public DeleteSalonServiceRequestValidator()
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
