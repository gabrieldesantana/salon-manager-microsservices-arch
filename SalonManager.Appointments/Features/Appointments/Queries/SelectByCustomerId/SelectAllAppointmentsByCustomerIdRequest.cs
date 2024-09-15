using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectByCustomerId
{
    public record SelectAllAppointmentsByCustomerIdRequest(Guid CustomerId, Guid TenantId)
        : IRequest<Result<SelectAllAppointmentsByCustomerIdResponse>>;
}
