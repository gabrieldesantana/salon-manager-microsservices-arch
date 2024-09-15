using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Customers.Features.Customers.Commands.IncreaseVisitedTimes
{
    public class IncreaseVisitedTimesRequestHandler : IRequestHandler<IncreaseVisitedTimesRequest, Result<IncreaseVisitedTimesResponse>>
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly ICustomerQueryRepository _queryRepository;
        private readonly IValidator<IncreaseVisitedTimesRequest> _validator;
        public IncreaseVisitedTimesRequestHandler(
            ICustomerCommandRepository commandRepository,
            ICustomerQueryRepository queryRepository,
            IValidator<IncreaseVisitedTimesRequest> validator)
            => (_commandRepository, _queryRepository, _validator) = (commandRepository, queryRepository, validator);

        public async Task<Result<IncreaseVisitedTimesResponse>> Handle(IncreaseVisitedTimesRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var customer = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (customer == null)
                return Result.Fail<IncreaseVisitedTimesResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o cliente de ID: {request.Id}");

            customer.IncreaseVisitedTimes(request.LastServiceName, request.LastServiceDate);

            var result = await _commandRepository.UpdateAsync(customer, request.Id);
            if (result == null)
                return Result.Fail<IncreaseVisitedTimesResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            return Result.Ok(new IncreaseVisitedTimesResponse(
                request.Id,
                request.TenantId,
                customer.LastServiceName!,
                customer.LastServiceDate
                ));
        }
    }
}
