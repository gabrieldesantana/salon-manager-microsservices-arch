using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.SalonServices.Commands.Delete
{
    public record DeleteSalonServiceRequest(Guid Id, Guid TenantId) 
        : IRequest<Result<DeleteSalonServiceResponse>>;
}
