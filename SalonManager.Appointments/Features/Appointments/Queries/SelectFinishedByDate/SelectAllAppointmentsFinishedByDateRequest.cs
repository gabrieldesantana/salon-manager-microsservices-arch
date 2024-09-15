using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectFinishedByDate
{
    public record SelectAllAppointmentsFinishedByDateRequest(Guid TenantId, DateTime StartDate, DateTime EndDate) 
        : IRequest<Result<SelectAllAppointmentsFinishedByDateResponse>>;
}
