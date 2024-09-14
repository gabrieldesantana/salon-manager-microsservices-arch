using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.CrossCutting.Models;
using SalonManager.Customers.Features.Customers.Queries.Select;

namespace SalonManager.Customers.Features.Customers.Queries.SelectAll
{
    internal class SelectAllCustomersRequestHandler : IRequestHandler<SelectAllCustomersRequest, Result<PagedResult<SelectCustomerResponse>>>
    {
        private readonly ICustomerQueryRepository _queryRepository;
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly IValidator<SelectAllCustomersRequest> _validator;
        public SelectAllCustomersRequestHandler(ICustomerQueryRepository queryRepository, ICustomerCommandRepository commandRepository, IValidator<SelectAllCustomersRequest> validator)
            => (_queryRepository, _commandRepository, _validator) = (queryRepository, commandRepository, validator);
        public async Task<Result<PagedResult<SelectCustomerResponse>>> Handle(SelectAllCustomersRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var customers = await _queryRepository.GetAllAsync(request.TenantId, request.PageNumber, request.PageSize);
            var totalCustomers = await _commandRepository.CountAsync(request.TenantId);

            return Result.Ok(SelectAllCustomersResponse.FromCustomersToPagedResult(customers, request.PageNumber, request.PageSize, totalCustomers));
        }
    }
}
