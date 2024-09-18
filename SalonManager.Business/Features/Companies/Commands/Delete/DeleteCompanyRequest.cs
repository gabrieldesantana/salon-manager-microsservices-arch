using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Companies.Commands.Delete
{
    public class DeleteCompanyRequest : IRequest<Result<DeleteCompanyResponse>>
    {
        public DeleteCompanyRequest(Guid id, Guid tenantId)
        {
            Id = id;
            TenantId = tenantId;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
    }
}
