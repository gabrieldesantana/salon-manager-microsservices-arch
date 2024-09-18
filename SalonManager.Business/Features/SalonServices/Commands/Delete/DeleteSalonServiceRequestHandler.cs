using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.SalonServices.Commands.Delete
{
    internal class DeleteSalonServiceRequestHandler : IRequestHandler<DeleteSalonServiceRequest, Result<DeleteSalonServiceResponse>>
    {
        private readonly ISalonServiceCommandRepository _commandRepository;
        private readonly IValidator<DeleteSalonServiceRequest> _validator;
        public DeleteSalonServiceRequestHandler(ISalonServiceCommandRepository commandRepository, IValidator<DeleteSalonServiceRequest> validator)
        => (_commandRepository, _validator) = (commandRepository, validator);

        public async Task<Result<DeleteSalonServiceResponse>> Handle(DeleteSalonServiceRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            bool status = await _commandRepository.DeleteAsync(request.Id, request.TenantId);

            if (status)
                return Result.Fail<DeleteSalonServiceResponse>($"{nameof(BadRequestException)}|Nao foi possivel excluir o servico de ID: {request.Id}");

            return Result.Ok(new DeleteSalonServiceResponse(request.Id, status));
        }
    }
}
