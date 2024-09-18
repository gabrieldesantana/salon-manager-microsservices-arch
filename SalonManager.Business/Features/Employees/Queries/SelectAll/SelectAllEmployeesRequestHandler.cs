using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Employees.Queries.Select;

namespace SalonManager.Business.Features.Employees.Queries.SelectAll
{
    internal class SelectAllEmployeesRequestHandler : IRequestHandler<SelectAllEmployeesRequest, Result<PagedResult<SelectEmployeeResponse>>>
    {
        private readonly IEmployeeQueryRepository _queryRepository;
        private readonly IEmployeeCommandRepository _commandRepository;
        private readonly IValidator<SelectAllEmployeesRequest> _validator;
        public SelectAllEmployeesRequestHandler(IEmployeeQueryRepository queryRepository, IEmployeeCommandRepository commandRepository, IValidator<SelectAllEmployeesRequest> validator)
            => (_queryRepository, _commandRepository, _validator) = (queryRepository, commandRepository, validator);

        public async Task<Result<PagedResult<SelectEmployeeResponse>>> Handle(SelectAllEmployeesRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var employees = await _queryRepository.GetAllAsync(request.TenantId, request.PageNumber, request.PageSize);
            var totalEmployees = await _commandRepository.CountAsync(request.TenantId);

            return Result.Ok(SelectAllEmployeesResponse.FromEmployeesToPagedResult(employees, request.PageNumber, request.PageSize, totalEmployees));
        }
    }
}
