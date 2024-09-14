using FluentResults;
using MediatR;

namespace SalonManager.Customers.Features.Customers.Queries.Select
{
    public record SelectCustomerRequest(Guid Id, Guid TenantId)
           : IRequest<Result<SelectCustomerResponse>>;
}
