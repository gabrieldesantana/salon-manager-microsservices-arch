using FluentValidation;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectAll
{
    public sealed class SelectAllAppointmentsRequestValidator : AbstractValidator<SelectAllAppointmentsRequest>
    {
        public SelectAllAppointmentsRequestValidator()
        {
            RuleFor(validation => validation.TenantId)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PageNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(validation => validation.PageSize)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
