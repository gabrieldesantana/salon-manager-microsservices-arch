using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectByCustomerId
{
    public sealed class SelectAllAppointmentsByCustomerIdRequestValidator : AbstractValidator<SelectAllAppointmentsByCustomerIdRequest>
    {
        public SelectAllAppointmentsByCustomerIdRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(x => x.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
