using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Customers.Features.Customers.Queries.Select
{
    internal class SelectCustomerRequestHandler : IRequestHandler<SelectCustomerRequest, Result<SelectCustomerResponse>>
    {
        private readonly ICustomerQueryRepository _queryRepository;
        private readonly IValidator<SelectCustomerRequest> _validator;
        public SelectCustomerRequestHandler(ICustomerQueryRepository queryRepository, IValidator<SelectCustomerRequest> validator)
            => (_queryRepository, _validator) = (queryRepository, validator);

        public async Task<Result<SelectCustomerResponse>> Handle(SelectCustomerRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var customer = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (customer == null)
                return Result.Fail<SelectCustomerResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o cliente de ID: {request.Id}");

            SelectCustomerResponse selectCustomerResponse = customer;
            return Result.Ok(selectCustomerResponse);
        }
    }
}
