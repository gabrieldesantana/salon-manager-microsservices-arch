using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Companies.Queries.Select
{
    public record SelectCompanyRequest(Guid TenantId, Guid Id) 
        : IRequest<Result<SelectCompanyResponse>>
    {
    }
}
