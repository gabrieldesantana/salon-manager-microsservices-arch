using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.SalonServices.Queries.Select
{
    public record SelectSalonServiceRequest(Guid Id, Guid TenantId) 
        : IRequest<Result<SelectSalonServiceResponse>>;
}
