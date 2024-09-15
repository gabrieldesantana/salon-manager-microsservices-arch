using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Queries.Select
{
    public sealed class SelectAppointmentRequestValidator : AbstractValidator<SelectAppointmentRequest>
    {
        public SelectAppointmentRequestValidator()
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
