using FluentResults;
using MediatR;
using SalonManager.Appointments.Core.Enums;

namespace SalonManager.Appointments.Features.Appointments.Commands.UpdateStatus
{
    public class UpdateStatusAppointmentRequest : IRequest<Result<UpdateStatusAppointmentResponse>>
    {
        public UpdateStatusAppointmentRequest(Guid id, Guid tenantId, EAppointmentStatus status)
        {
            Id = id;
            TenantId = tenantId;
            Status = status;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public EAppointmentStatus Status { get; private set; }
    }
}
