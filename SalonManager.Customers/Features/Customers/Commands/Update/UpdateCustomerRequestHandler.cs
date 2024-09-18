using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Customers.Features.Customers.Commands.Update
{
    internal class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, Result<UpdateCustomerResponse>>
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly ICustomerQueryRepository _queryRepository;
        private readonly IValidator<UpdateCustomerRequest> _validator;
        public UpdateCustomerRequestHandler(
            ICustomerCommandRepository commandRepository,
            ICustomerQueryRepository queryRepository,
            IValidator<UpdateCustomerRequest> validator)
            => (_commandRepository, _queryRepository, _validator) = (commandRepository, queryRepository, validator);
        public async Task<Result<UpdateCustomerResponse>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var customer = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (customer == null)
                return Result.Fail<UpdateCustomerResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o cliente de ID: {request.Id}");

            customer.Update(
                request.Cpf, request.Name,
                request.Nickname, request.Gender,
                request.BirthDate, request.PhoneNumber
                );

            var result = await _commandRepository.UpdateAsync(customer, request.Id);
            if (result == null)
                return Result.Fail<UpdateCustomerResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            UpdateCustomerResponse updateCustomerResponse = customer;
            return Result.Ok(updateCustomerResponse);
        }
    }
}
