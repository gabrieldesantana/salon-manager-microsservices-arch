using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Commands.Finish
{
    public sealed class FinishAppointmentRequestValidator : AbstractValidator<FinishAppointmentRequest>
    {
        public FinishAppointmentRequestValidator()
        {
            RuleFor(validation => validation.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.TenantId)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PaymentMethod)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PaymentWay)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Earnings)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Details)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
