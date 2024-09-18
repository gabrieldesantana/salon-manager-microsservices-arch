using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.Employees.Commands.Delete
{
    internal class DeleteEmployeeRequestHandler : IRequestHandler<DeleteEmployeeRequest, Result<DeleteEmployeeResponse>>
    {
        private readonly IEmployeeCommandRepository _commandRepository;
        private readonly IValidator<DeleteEmployeeRequest> _validator;
        public DeleteEmployeeRequestHandler(IEmployeeCommandRepository commandRepository, IValidator<DeleteEmployeeRequest> validator)
            => (_commandRepository, _validator) = (commandRepository, validator);

        public async Task<Result<DeleteEmployeeResponse>> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            bool status = await _commandRepository.DeleteAsync(request.Id, request.TenantId);

            if (status)
                return Result.Fail<DeleteEmployeeResponse>($"{nameof(BadRequestException)}|Nao foi possivel excluir o empregado de ID: {request.Id}");

            return Result.Ok(new DeleteEmployeeResponse(request.Id, status));
        }
    }
}
