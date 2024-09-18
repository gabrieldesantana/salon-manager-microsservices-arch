using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Companies.Queries.Select;

namespace SalonManager.Business.Features.Companies.Queries.SelectAll
{
    internal class SelectAllCompaniesRequestHandler : IRequestHandler<SelectAllCompaniesRequest, Result<PagedResult<SelectCompanyResponse>>>
    {
        private readonly ICompanyQueryRepository _queryRepository;
        private readonly IValidator<SelectAllCompaniesRequest> _validator;
        public SelectAllCompaniesRequestHandler(ICompanyQueryRepository queryRepository, IValidator<SelectAllCompaniesRequest> validator)
            => (_queryRepository, _validator) = (queryRepository, validator);

        public async Task<Result<PagedResult<SelectCompanyResponse>>> Handle(SelectAllCompaniesRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var companies = await _queryRepository.GetAllAsync(request.PageNumber, request.PageSize);

            var companiesPaged = companies
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize)
            .ToList();

            return Result.Ok(SelectAllCompaniesResponse.FromCustomersToPagedResult(companies, request.PageNumber, request.PageSize));
        }
    }
}
