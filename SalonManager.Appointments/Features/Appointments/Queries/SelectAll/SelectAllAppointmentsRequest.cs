using FluentResults;
using MediatR;
using SalonManager.Appointments.CrossCutting.Models;
using SalonManager.Appointments.Features.Appointments.Queries.Select;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectAll
{
    public record SelectAllAppointmentsRequest(Guid TenantId, int PageNumber, int PageSize) 
        : IRequest<Result<PagedResult<SelectAppointmentResponse>>>;
}
