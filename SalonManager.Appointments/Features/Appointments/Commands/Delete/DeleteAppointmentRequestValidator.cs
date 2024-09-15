using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Commands.Delete
{
    public sealed class DeleteAppointmentRequestValidator : AbstractValidator<DeleteAppointmentRequest>
    {
        public DeleteAppointmentRequestValidator()
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
