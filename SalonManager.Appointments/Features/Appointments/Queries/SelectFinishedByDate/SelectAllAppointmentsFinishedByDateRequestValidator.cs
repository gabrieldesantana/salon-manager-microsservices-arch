using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectFinishedByDate
{
    public sealed class SelectAllAppointmentsFinishedByDateRequestValidator : AbstractValidator<SelectAllAppointmentsFinishedByDateRequest>
    {
        public SelectAllAppointmentsFinishedByDateRequestValidator()
        {
            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.StartDate)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.EndDate)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
