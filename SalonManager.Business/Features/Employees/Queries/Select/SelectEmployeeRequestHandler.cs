using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;
using SalonManager.Business.Infrastructure.Refit;

namespace SalonManager.Business.Features.Employees.Queries.Select
{
    internal class SelectEmployeeRequestHandler : IRequestHandler<SelectEmployeeRequest, Result<SelectEmployeeResponse>>
    {
        private readonly IEmployeeQueryRepository _queryRepository;
        private readonly IAppointmentServiceRefit _appointmentServiceRefit;
        private readonly IValidator<SelectEmployeeRequest> _validator;
        public SelectEmployeeRequestHandler(IEmployeeQueryRepository queryRepository, IAppointmentServiceRefit appointmentServiceRefit, IValidator<SelectEmployeeRequest> validator)
            => (_queryRepository, _appointmentServiceRefit, _validator) = (queryRepository, appointmentServiceRefit, validator);

        public async Task<Result<SelectEmployeeResponse>> Handle(SelectEmployeeRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var employee = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (employee == null)
                return Result.Fail<SelectEmployeeResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o empregado de ID: {request.Id}");

            var appointmentsByEmployeeResult = await _appointmentServiceRefit.GetAppointmentsByEmployeeAsync(request.TenantId, request.Id);

            if (!appointmentsByEmployeeResult.IsSuccessStatusCode || appointmentsByEmployeeResult.Content == null)
                return Result.Fail<SelectEmployeeResponse>($"{nameof(ApiException)}|Nao foi possivel obter o cliente");

            employee.Appointments = appointmentsByEmployeeResult.Content.Appointments;

            SelectEmployeeResponse selectEmployeeResponse = employee;
            return Result.Ok(selectEmployeeResponse);
        }
    }
}
