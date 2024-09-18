namespace SalonManager.Business.Core.Entities
{
    public class SalonService : BaseEntity
    {
        protected SalonService() { }

        public SalonService(Guid tenantId, Guid userCreatorId, string? name, string? category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
        }

        public string? Name { get; private set; }
        public string? Category { get; private set; }
        public double Price { get; private set; }

        public void Update(string? name, string? category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }
    }
}
