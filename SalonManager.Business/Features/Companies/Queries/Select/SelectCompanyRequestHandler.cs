using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.Companies.Queries.Select
{
    public class SelectCompanyRequestHandler : IRequestHandler<SelectCompanyRequest, Result<SelectCompanyResponse>>
    {
        private readonly ICompanyQueryRepository _queryRepository;
        private readonly IValidator<SelectCompanyRequest> _validator;
        public SelectCompanyRequestHandler(ICompanyQueryRepository queryRepository, IValidator<SelectCompanyRequest> validator)
            => (_queryRepository, _validator) = (queryRepository, validator);

        public async Task<Result<SelectCompanyResponse>> Handle(SelectCompanyRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var company = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);
            if (company == null)
                return Result.Fail<SelectCompanyResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar a empresa de ID: {request.Id}");

            SelectCompanyResponse selectCompanyResponse = company;
            return Result.Ok(selectCompanyResponse);
        }
    }
}
