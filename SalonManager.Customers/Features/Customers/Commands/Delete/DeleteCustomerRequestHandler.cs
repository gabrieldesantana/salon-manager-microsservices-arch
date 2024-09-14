using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Customers.Features.Customers.Commands.Delete
{
    internal class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest, Result<DeleteCustomerResponse>>
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly IValidator<DeleteCustomerRequest> _validator;
        public DeleteCustomerRequestHandler(ICustomerCommandRepository commandRepository, IValidator<DeleteCustomerRequest> validator)
        {
            _commandRepository = commandRepository;
            _validator = validator;
        }
        public async Task<Result<DeleteCustomerResponse>> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            bool status = await _commandRepository.DeleteAsync(request.Id, request.TenantId);

            if (status)
                return Result.Fail<DeleteCustomerResponse>($"{nameof(BadRequestException)}|Nao foi possivel excluir o cliente de ID: {request.Id}");

            return Result.Ok(new DeleteCustomerResponse(request.Id, status!));
        }
    }
}
