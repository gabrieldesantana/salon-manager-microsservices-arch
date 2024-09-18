using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.Employees.Commands.Update
{
    internal class UpdateEmployeeRequestHandler : IRequestHandler<UpdateEmployeeRequest, Result<UpdateEmployeeResponse>>
    {
        private readonly IEmployeeCommandRepository _commandRepository;
        private readonly IEmployeeQueryRepository _queyRepository;
        private readonly IValidator<UpdateEmployeeRequest> _validator;
        public UpdateEmployeeRequestHandler(IEmployeeCommandRepository commandRepository, IEmployeeQueryRepository queyRepository, IValidator<UpdateEmployeeRequest> validator)
            => (_commandRepository, _queyRepository, _validator) = (commandRepository, queyRepository, validator);

        public async Task<Result<UpdateEmployeeResponse>> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var employee = await _queyRepository.GetByIdAsync(request.Id, request.TenantId);

            if (employee == null)
                return Result.Fail<UpdateEmployeeResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o empregado de ID: {request.Id}");

            employee.Update(
                request.Cpf, request.Name,
                request.Nickname, request.Gender,
                request.BirthDate, request.PhoneNumber
                );

            var result = await _commandRepository.UpdateAsync(employee, request.Id);
            if (result == null)
                return Result.Fail<UpdateEmployeeResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            UpdateEmployeeResponse updateEmployeeResponse = employee;

            return Result.Ok(updateEmployeeResponse);
        }
    }
}
