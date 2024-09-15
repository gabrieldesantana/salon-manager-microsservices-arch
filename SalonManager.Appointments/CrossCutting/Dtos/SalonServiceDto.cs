namespace SalonManager.Appointments.CrossCutting.Dtos
{
    public class SalonServiceDto
    {
        public SalonServiceDto(Guid tenantId, Guid userCreatorId, string? name, string? category, double price)
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

        #region BaseEntity
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid TenantId { get; set; }
        public Guid UserCreatorId { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool IsActived { get; set; }

        #endregion  
    }
}
