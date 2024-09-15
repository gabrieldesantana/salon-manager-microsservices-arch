using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Commands.UpdateStatus
{
    public sealed class UpdateStatusAppointmentRequestValidator : AbstractValidator<UpdateStatusAppointmentRequest>
    {
        public UpdateStatusAppointmentRequestValidator()
        {
            RuleFor(validation => validation.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.Status)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
