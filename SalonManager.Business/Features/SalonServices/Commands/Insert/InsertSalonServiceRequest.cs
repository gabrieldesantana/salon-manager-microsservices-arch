using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.SalonServices.Commands.Insert
{
    public class InsertSalonServiceRequest: IRequest<Result<InsertSalonServiceResponse>>
    {
        public InsertSalonServiceRequest(Guid tenantId, Guid userCreatorId, string? name, string? category, double price)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
            Name = name;
            Category = category;
            Price = price;
        }

        public Guid TenantId { get; private set; }
        public Guid UserCreatorId { get; private set; }
        public string? Name { get; private set; }
        public string? Category { get; private set; }
        public double Price { get; private set; }
    }
}
