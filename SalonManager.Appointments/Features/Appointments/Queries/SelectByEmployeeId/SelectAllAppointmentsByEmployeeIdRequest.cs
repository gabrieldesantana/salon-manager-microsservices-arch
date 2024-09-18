using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectByEmployeeId
{
    public record SelectAllAppointmentsByEmployeeIdRequest(Guid EmployeeId, Guid TenantId)
        : IRequest<Result<SelectAllAppointmentsByEmployeeIdResponse>>;
}
