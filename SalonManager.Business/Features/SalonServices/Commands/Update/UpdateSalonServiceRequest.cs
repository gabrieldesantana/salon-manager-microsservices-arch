using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.SalonServices.Commands.Update
{
    public class UpdateSalonServiceRequest : IRequest<Result<UpdateSalonServiceResponse>>
    {
        public UpdateSalonServiceRequest(Guid id, Guid tenantId, string? name, string? category, double price)
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
    }
}
