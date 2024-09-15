using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Commands.Insert
{
    public sealed class InsertAppointmentRequestValidator : AbstractValidator<InsertAppointmentRequest>
    {
        public InsertAppointmentRequestValidator()
        {
            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.UserCreatorId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.CustomerAppointmentId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.ServiceAppointmentId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.EmployeeAppointmentId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.AppointmentDate)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");

        }
    }
}
