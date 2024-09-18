using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Features.SalonServices.Queries.Select
{
    public class SelectSalonServiceResponse
    {
        public SelectSalonServiceResponse(Guid id, Guid tenantId, string? name, string? category, double price)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
            Category = category;
            Price = price;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string? Name { get; private set; }
        public string? Category { get; private set; }
        public double Price { get; private set; }

        public static SelectSalonServiceResponse FromSalonService(SalonService salonService)
            => new(
                salonService.Id,
                salonService.TenantId,
                salonService.Name,
                salonService.Category,
                salonService.Price
                );

        public static implicit operator SelectSalonServiceResponse(SalonService salonService)
            => new(
                salonService.Id,
                salonService.TenantId,
                salonService.Name,
                salonService.Category,
                salonService.Price
                );
    }
}
