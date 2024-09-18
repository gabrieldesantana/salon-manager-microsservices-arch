using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Employees.Commands.Delete
{
    public record DeleteEmployeeRequest(Guid Id, Guid TenantId) 
        : IRequest<Result<DeleteEmployeeResponse>>;
}
