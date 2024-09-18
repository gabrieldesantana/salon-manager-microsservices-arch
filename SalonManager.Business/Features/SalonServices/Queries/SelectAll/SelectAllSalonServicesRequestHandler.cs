using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.SalonServices.Queries.Select;

namespace SalonManager.Business.Features.SalonServices.Queries.SelectAll
{
    internal class SelectAllSalonServicesRequestHandler : IRequestHandler<SelectAllSalonServicesRequest, Result<PagedResult<SelectSalonServiceResponse>>>
    {

        private readonly ISalonServiceQueryRepository _queryRepository;
        private readonly ISalonServiceCommandRepository _commandRepository;
        private readonly IValidator<SelectAllSalonServicesRequest> _validator;
        public SelectAllSalonServicesRequestHandler(ISalonServiceQueryRepository queryRepository, ISalonServiceCommandRepository commandRepository, IValidator<SelectAllSalonServicesRequest> validator)
            => (_queryRepository, _commandRepository, _validator) = (queryRepository, commandRepository, validator);

        public async Task<Result<PagedResult<SelectSalonServiceResponse>>> Handle(SelectAllSalonServicesRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var salonServices = await _queryRepository.GetAllAsync(request.TenantId, request.PageNumber, request.PageSize);
            var totalSalonServices = await _commandRepository.CountAsync(request.TenantId);

            return Result.Ok(SelectAllSalonServicesResponse.FromSalonServicesToPagedResult(salonServices, request.PageNumber, request.PageSize, totalSalonServices));
        }
    }
}
