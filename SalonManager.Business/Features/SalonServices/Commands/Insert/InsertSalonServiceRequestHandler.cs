using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.SalonServices.Commands.Insert
{
    internal class InsertSalonServiceRequestHandler : IRequestHandler<InsertSalonServiceRequest, Result<InsertSalonServiceResponse>>
    {
        private readonly ISalonServiceCommandRepository _commandRepository;
        private readonly IValidator<InsertSalonServiceRequest> _validator;
        public InsertSalonServiceRequestHandler(ISalonServiceCommandRepository commandRepository, IValidator<InsertSalonServiceRequest> validator)
            => (_commandRepository, _validator) = (commandRepository, validator);
        public async Task<Result<InsertSalonServiceResponse>> Handle(InsertSalonServiceRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var salonService = new SalonService(
                request.TenantId,
                request.UserCreatorId,
                request.Name,
                request.Category,
                request.Price
                );

            var result = await _commandRepository.InsertAsync(salonService);

            if (result == null)
                return Result.Fail<InsertSalonServiceResponse>($"{nameof(BadRequestException)}|Nao foi possivel inserir o servico");

            InsertSalonServiceResponse insertSalonServiceResponse = salonService;
            return insertSalonServiceResponse;
        }
    }
}
