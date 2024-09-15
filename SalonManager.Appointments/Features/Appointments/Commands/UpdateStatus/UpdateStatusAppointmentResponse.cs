using SalonManager.Appointments.Core.Enums;

namespace SalonManager.Appointments.Features.Appointments.Commands.UpdateStatus
{
    public record UpdateStatusAppointmentResponse(Guid Id, EAppointmentStatus Status);
}
