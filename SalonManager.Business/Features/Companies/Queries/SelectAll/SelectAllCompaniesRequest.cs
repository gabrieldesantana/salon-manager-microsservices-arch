using FluentResults;
using MediatR;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Companies.Queries.Select;

namespace SalonManager.Business.Features.Companies.Queries.SelectAll
{
    public record SelectAllCompaniesRequest(int PageNumber, int PageSize) 
        : IRequest<Result<PagedResult<SelectCompanyResponse>>>;
}
