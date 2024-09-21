namespace SalonManager.Business.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            IsActived = true;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; private set; }

        public Guid TenantId { get; set; }
        public Guid UserCreatorId { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool IsActived { get; set; }
    }
}
