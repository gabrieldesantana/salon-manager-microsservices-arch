using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Companies.Commands.Update
{
    public class UpdateCompanyRequest : IRequest<Result<UpdateCompanyResponse>>
    {
        public UpdateCompanyRequest(Guid id, Guid tenantId, string? name, string? cNPJ)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
            CNPJ = cNPJ;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string? Name { get; private set; }
        public string? CNPJ { get; private set; }
    }
}
