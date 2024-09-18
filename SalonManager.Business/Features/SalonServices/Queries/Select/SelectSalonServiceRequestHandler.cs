using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.SalonServices.Queries.Select
{
    internal class SelectSalonServiceRequestHandler : IRequestHandler<SelectSalonServiceRequest, Result<SelectSalonServiceResponse>>
    {
        private readonly ISalonServiceQueryRepository _queryRepository;
        private readonly IValidator<SelectSalonServiceRequest> _validator;
        public SelectSalonServiceRequestHandler(ISalonServiceQueryRepository queryRepository, IValidator<SelectSalonServiceRequest> validator)
            => (_queryRepository, _validator) = (queryRepository, validator);

        public async Task<Result<SelectSalonServiceResponse>> Handle(SelectSalonServiceRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var salonService = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (salonService == null)
                return Result.Fail<SelectSalonServiceResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o servico de ID: {request.Id}");

            SelectSalonServiceResponse selectCompanyResponse = salonService;
            return Result.Ok(selectCompanyResponse);
        }
    }
}
