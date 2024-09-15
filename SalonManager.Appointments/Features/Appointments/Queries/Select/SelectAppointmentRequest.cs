using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Queries.Select
{
    public record SelectAppointmentRequest(Guid Id, Guid TenantId) 
        : IRequest<Result<SelectAppointmentResponse>>;
}
