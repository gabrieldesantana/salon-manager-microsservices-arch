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
        private readonly IValidator<UpdateCustomerRequest> _validator;
        public UpdateCustomerRequestHandler(ICustomerCommandRepository commandRepository, IValidator<UpdateCustomerRequest> validator)
            => (_commandRepository, _validator) = (commandRepository, validator);
        public async Task<Result<UpdateCustomerResponse>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var customer = await _commandRepository.GetByIdAsync(request.Id, request.TenantId);

            if (customer == null)
                return Result.Fail<UpdateCustomerResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o cliente de ID: {request.Id}");

            customer.Update(
                request.Cpf, request.Name,
                request.Nickname, request.Gender,
                request.BirthDate, request.PhoneNumber
                );

            await _commandRepository.SaveChangesAsync();

            UpdateCustomerResponse updateCustomerResponse = customer;
            return Result.Ok(updateCustomerResponse);
        }
    }
}
