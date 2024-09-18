using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectByEmployeeId
{
    public sealed class SelectAllAppointmentsByEmployeeIdRequestValidator : AbstractValidator<SelectAllAppointmentsByEmployeeIdRequest>
    {
        public SelectAllAppointmentsByEmployeeIdRequestValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(x => x.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
