using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Features.Companies.Queries.Select
{
    public class SelectCompanyResponse
    {
        public SelectCompanyResponse(Guid id, Guid tenantId, string? name, string? cNPJ, List<Employee>? employees)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
            CNPJ = cNPJ;
            Employees = employees;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string? Name { get; private set; }
        public string? CNPJ { get; private set; }
        public List<Employee>? Employees { get; private set; }

        public const bool INCLUDEOBJECTS = true;

        public static SelectCompanyResponse FromCompany(Company company, bool includeObjects)
        => new(
            company.Id,
            company.TenantId,
            company.Name,
            company.CNPJ,
            (includeObjects) ? company.Employees : null
            );

        public static implicit operator SelectCompanyResponse(Company company)
        => new(
        company.Id,
        company.TenantId,
        company.Name,
        company.CNPJ,
        (INCLUDEOBJECTS) ? company.Employees : null
        );
    }
}
