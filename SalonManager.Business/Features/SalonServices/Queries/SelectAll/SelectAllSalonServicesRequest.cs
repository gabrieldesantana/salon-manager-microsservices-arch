using FluentResults;
using MediatR;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.SalonServices.Queries.Select;

namespace SalonManager.Business.Features.SalonServices.Queries.SelectAll
{
    public record SelectAllSalonServicesRequest(Guid TenantId, int PageNumber, int PageSize)
        : IRequest<Result<PagedResult<SelectSalonServiceResponse>>>;
}
