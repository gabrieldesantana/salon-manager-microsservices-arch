using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.SalonServices.Commands.Update
{
    internal class UpdateSalonServiceRequestHandler : IRequestHandler<UpdateSalonServiceRequest, Result<UpdateSalonServiceResponse>>
    {
        private readonly IValidator<UpdateSalonServiceRequest> _validator;
        private readonly ISalonServiceCommandRepository _commandRepository;
        private readonly ISalonServiceQueryRepository _queryRepository;

        public UpdateSalonServiceRequestHandler(ISalonServiceCommandRepository commandRepository, ISalonServiceQueryRepository queryRepository, IValidator<UpdateSalonServiceRequest> validator)
        => (_commandRepository, _queryRepository, _validator) = (commandRepository, queryRepository, validator);

        public async Task<Result<UpdateSalonServiceResponse>> Handle(UpdateSalonServiceRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var salonService = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (salonService == null)
                return Result.Fail<UpdateSalonServiceResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o servico de ID: {request.Id}");

            salonService.Update(request.Name, request.Category, request.Price);

            var result = await _commandRepository.UpdateAsync(salonService, request.Id);
            if (result == null)
                return Result.Fail<UpdateSalonServiceResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            UpdateSalonServiceResponse updateSalonServiceResponse = salonService;
            return Result.Ok(updateSalonServiceResponse);

        }
    }
}
