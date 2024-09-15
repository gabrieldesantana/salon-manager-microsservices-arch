using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Commands.Update
{

    public class UpdateAppointmentRequest : IRequest<Result<UpdateAppointmentResponse>>
    {
        public UpdateAppointmentRequest(
            Guid id, Guid tenantId,DateTime appointmentDate,
            string details)
        {
            Id = id;
            TenantId = tenantId;
            AppointmentDate = DateTime.SpecifyKind(appointmentDate, DateTimeKind.Unspecified);
            Details = details;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public string? Details { get; private set; }
    }
}
