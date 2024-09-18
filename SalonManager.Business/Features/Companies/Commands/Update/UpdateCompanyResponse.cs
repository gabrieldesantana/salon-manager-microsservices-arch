using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Features.Companies.Commands.Update
{
    public class UpdateCompanyResponse
    {
        public UpdateCompanyResponse(Guid id, Guid tenantId, string? name, string? cNPJ)
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

        public static implicit operator UpdateCompanyResponse(Company company)
            => new(
                company.Id,
                company.TenantId,
                company.Name,
                company.CNPJ
                );
    }
}
