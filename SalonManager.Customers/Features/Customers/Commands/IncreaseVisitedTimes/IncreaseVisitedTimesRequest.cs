using FluentResults;
using MediatR;

namespace SalonManager.Customers.Features.Customers.Commands.IncreaseVisitedTimes
{
    public class IncreaseVisitedTimesRequest : IRequest<Result<IncreaseVisitedTimesResponse>>
    {
        public IncreaseVisitedTimesRequest(Guid id, Guid tenantId, string lastServiceName, DateTime lastServiceDate)
        {
            Id = id;
            TenantId = tenantId;
            LastServiceName = lastServiceName;
            LastServiceDate = lastServiceDate;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string LastServiceName { get; private set; }
        public DateTime LastServiceDate { get; private set; }
    }
}
