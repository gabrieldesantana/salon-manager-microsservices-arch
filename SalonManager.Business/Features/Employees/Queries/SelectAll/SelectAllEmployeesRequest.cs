using FluentResults;
using MediatR;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Employees.Queries.Select;

namespace SalonManager.Business.Features.Employees.Queries.SelectAll
{
    public record SelectAllEmployeesRequest(Guid TenantId, int PageNumber, int PageSize)
        : IRequest<Result<PagedResult<SelectEmployeeResponse>>>;
}
