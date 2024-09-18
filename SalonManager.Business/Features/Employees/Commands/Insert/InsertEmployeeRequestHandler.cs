using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.Employees.Commands.Insert
{
    internal class InsertEmployeeRequestHandler : IRequestHandler<InsertEmployeeRequest, Result<InsertEmployeeResponse>>
    {
        private readonly IEmployeeCommandRepository _commandRepository;
        private readonly IValidator<InsertEmployeeRequest> _validator;

        public InsertEmployeeRequestHandler(IEmployeeCommandRepository commandRepository, IValidator<InsertEmployeeRequest> validator)
            => (_commandRepository, _validator) = (commandRepository, validator);

        public async Task<Result<InsertEmployeeResponse>> Handle(InsertEmployeeRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            Employee employee = new(
                request.TenantId,
                request.UserCreatorId,
                request.UserId,
                request.CompanyId,
                request.Cpf,
                request.Name,
                request.Nickname,
                request.Gender,
                request.BirthDate,
                request.PhoneNumber
                );

            var result = await _commandRepository.InsertAsync(employee);

            if (result == null)
                return Result.Fail<InsertEmployeeResponse>($"{nameof(BadRequestException)}|Nao foi possivel inserir o empregado");

            ////var user = await _userQueryRepository.GetByIdAsync(request.UserId);
            ////user.ActivateUser(request.Name);
            ////await _commandRepository.SaveChangesAsync();

            InsertEmployeeResponse insertEmployeeResponse = result;
            return Result.Ok(insertEmployeeResponse);
        }
    }
}
