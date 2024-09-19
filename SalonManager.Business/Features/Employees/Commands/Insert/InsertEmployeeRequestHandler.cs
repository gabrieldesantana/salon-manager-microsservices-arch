using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;
using SalonManager.Business.Infrastructure.Refit;

namespace SalonManager.Business.Features.Employees.Commands.Insert
{
    internal class InsertEmployeeRequestHandler : IRequestHandler<InsertEmployeeRequest, Result<InsertEmployeeResponse>>
    {
        private readonly IEmployeeCommandRepository _commandRepository;
        private readonly IUserServiceRefit _userServiceRefit;
        private readonly IValidator<InsertEmployeeRequest> _validator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InsertEmployeeRequestHandler(
            IEmployeeCommandRepository commandRepository,
            IUserServiceRefit userServiceRefit,
            IValidator<InsertEmployeeRequest> validator,
            IHttpContextAccessor httpContextAccessor)
            => (_commandRepository, _userServiceRefit, _validator, _httpContextAccessor) = (commandRepository, userServiceRefit, validator, httpContextAccessor);

        public async Task<Result<InsertEmployeeResponse>> Handle(InsertEmployeeRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            Employee employee = new(
                request.TenantId,
                request.UserCreatorId,
                request.UserId,
                request.CompanyId,
                request.Cpf,
                request.FullName,
                request.Nickname,
                request.Gender,
                request.BirthDate,
                request.PhoneNumber
                );

            var result = await _commandRepository.InsertAsync(employee);

            if (result == null)
                return Result.Fail<InsertEmployeeResponse>($"{nameof(BadRequestException)}|Nao foi possivel inserir o empregado");

            var authorizationHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"];
            if (!authorizationHeader.ToString().StartsWith("Bearer"))
            {
                return Result.Fail<InsertEmployeeResponse>($"{nameof(UnauthorizedException)}|Nao foi possivel resgatar o token");
            }
            var token = authorizationHeader.ToString();

            var activateUserResult = await _userServiceRefit.ActivateUserAsync(token, new(employee.UserId, employee.FullName!));

            if (!activateUserResult.IsSuccessStatusCode || activateUserResult.Content == null)
                return Result.Fail<InsertEmployeeResponse>($"{nameof(ApiException)}|Nao foi possivel ativar o usuario vinculado ao cliente");

            InsertEmployeeResponse insertEmployeeResponse = result;
            return Result.Ok(insertEmployeeResponse);
        }
    }
}
