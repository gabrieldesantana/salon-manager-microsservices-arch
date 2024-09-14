using FluentResults;
using MediatR;

namespace SalonManager.Customers.Features.Customers.Commands.Delete
{
    public class DeleteCustomerRequest : IRequest<Result<DeleteCustomerResponse>>
    {
        public DeleteCustomerRequest(Guid id, Guid tenantId)
        {
            Id = id;
            TenantId = tenantId;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
    }
}
