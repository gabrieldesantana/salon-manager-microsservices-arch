using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Employees.Queries.Select
{
    public record SelectEmployeeRequest(Guid Id, Guid TenantId) 
        : IRequest<Result<SelectEmployeeResponse>>;
}
