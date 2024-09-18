namespace SalonManager.Business.Core.Entities
{
    public class Company : BaseEntity
    {
        protected Company()
        {
            Employees = [];
        }

        public Company(Guid tenantId, Guid userCreatorId, string? name, string? cNPJ)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
            Name = name;
            CNPJ = cNPJ;
            Employees = [];
        }
        public string? Name { get; private set; }
        public string? CNPJ { get; private set; }
        public List<Employee>? Employees { get; private set; }

        public void Update(string? name, string? cnpj)
        {
            Name = name;
            CNPJ = cnpj;
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }
    }
}
