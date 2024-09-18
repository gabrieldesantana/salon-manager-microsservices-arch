using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.CrossCutting.Exceptions;
using SalonManager.Customers.Infrastructure.Refit;

namespace SalonManager.Customers.Features.Customers.Queries.Select
{
    internal class SelectCustomerRequestHandler : IRequestHandler<SelectCustomerRequest, Result<SelectCustomerResponse>>
    {
        private readonly ICustomerQueryRepository _queryRepository;
        private readonly IAppointmentServiceRefit _appointmentServiceRefit;
        private readonly IValidator<SelectCustomerRequest> _validator;
        public SelectCustomerRequestHandler(ICustomerQueryRepository queryRepository, IAppointmentServiceRefit appointmentServiceRefit, IValidator<SelectCustomerRequest> validator)
            => (_queryRepository, _appointmentServiceRefit, _validator) = (queryRepository, appointmentServiceRefit, validator);

        public async Task<Result<SelectCustomerResponse>> Handle(SelectCustomerRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var customer = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (customer == null)
                return Result.Fail<SelectCustomerResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o cliente de ID: {request.Id}");

            var appointmentsByCustomerResult = await _appointmentServiceRefit.GetAppointmentsByCustomerAsync(request.TenantId, request.Id);

            if (!appointmentsByCustomerResult.IsSuccessStatusCode || appointmentsByCustomerResult.Content == null)
                return Result.Fail<SelectCustomerResponse>($"{nameof(ApiException)}|Nao foi possivel obter o cliente");

            customer.Appointments = appointmentsByCustomerResult.Content.Appointments;

            SelectCustomerResponse selectCustomerResponse = customer;
            return Result.Ok(selectCustomerResponse);
        }
    }
}
