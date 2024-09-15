using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentResponse
    {
        public UpdateAppointmentResponse(
        Guid id,
        Guid tenant,
        DateTime appointmentDate,
        string details)
        {
            Id = id;
            TenantId = tenant;
            AppointmentDate = appointmentDate;
            Details = details;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public string? Details { get; private set; }

        public static implicit operator UpdateAppointmentResponse(Appointment appointment)
            => new(
                appointment.Id,
                appointment.TenantId,
                appointment.AppointmentDate,
                appointment.Details
                );

        public static UpdateAppointmentResponse FromAppointment(Appointment appointment)
        => new(
            appointment.Id,
            appointment.TenantId,
            appointment.AppointmentDate,
            appointment.Details
        );
    }
}
