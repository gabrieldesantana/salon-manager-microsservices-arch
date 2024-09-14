using FluentResults;
using MediatR;
using SalonManager.Customers.CrossCutting.Models;
using SalonManager.Customers.Features.Customers.Queries.Select;

namespace SalonManager.Customers.Features.Customers.Queries.SelectAll
{
    public record SelectAllCustomersRequest(Guid TenantId, int PageNumber, int PageSize)
           : IRequest<Result<PagedResult<SelectCustomerResponse>>>;
}
