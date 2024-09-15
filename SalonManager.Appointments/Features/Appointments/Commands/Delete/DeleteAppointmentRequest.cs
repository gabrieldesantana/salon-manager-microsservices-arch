using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Commands.Delete
{
    public class DeleteAppointmentRequest : IRequest<Result<DeleteAppointmentResponse>>
    {
        public DeleteAppointmentRequest(Guid id, Guid tenantId)
        {
            Id = id;
            TenantId = tenantId;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
    }
}
