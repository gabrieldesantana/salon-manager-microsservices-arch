using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Infrastructure.Refit;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Appointments.Features.Appointments.Commands.Insert
{
    internal class InsertAppointmentRequestHandler : IRequestHandler<InsertAppointmentRequest, Result<InsertAppointmentResponse>>
    {
        private readonly IAppointmentCommandRepository _appointmentCommandRepository;
        private readonly ICustomerServiceRefit _customerServiceRefit;
        private readonly ISalonServiceServiceRefit _salonServiceRefit;
        private readonly IEmployeeServiceRefit _employeeServiceRefit;

        private readonly IValidator<InsertAppointmentRequest> _validator;
        public InsertAppointmentRequestHandler(
            IAppointmentCommandRepository appointmentCommandRepository,
            ICustomerServiceRefit customerServiceRefit,
            ISalonServiceServiceRefit salonServiceRefit,
            IEmployeeServiceRefit employeeServiceRefit,

        IValidator<InsertAppointmentRequest> validator
            )
        {
            _appointmentCommandRepository = appointmentCommandRepository;
            _customerServiceRefit = customerServiceRefit;
            _salonServiceRefit = salonServiceRefit;
            _employeeServiceRefit = employeeServiceRefit;
            _validator = validator;
        }
        public async Task<Result<InsertAppointmentResponse>> Handle(InsertAppointmentRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var customerResult = await _customerServiceRefit.GetCustomerAsync(request.TenantId, request.CustomerAppointmentId);

            if (!customerResult.IsSuccessStatusCode || customerResult.Content == null)
                return Result.Fail<InsertAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel obter o cliente");

            var salonServiceResult = await _salonServiceRefit.GetSalonServiceAsync(request.TenantId, request.ServiceAppointmentId);

            if (!salonServiceResult.IsSuccessStatusCode || salonServiceResult.Content == null)
                return Result.Fail<InsertAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel obter o servico");

            var employeeResult = await _employeeServiceRefit.GetEmployeeAsync(request.TenantId, request.EmployeeAppointmentId);

            if (!employeeResult.IsSuccessStatusCode || employeeResult.Content == null)
                return Result.Fail<InsertAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel obter o empregado");

            Appointment appointment = new (
                customerResult.Content.Id,
                salonServiceResult.Content.Id,
                employeeResult.Content.Id,
                request.UserCreatorId, request.TenantId, request.Details, request.AppointmentDate);

            var result = await _appointmentCommandRepository.InsertAsync(appointment);
            if (result == null)
                return Result.Fail<InsertAppointmentResponse>($"{nameof(BadRequestException)}|Nao foi possivel inserir o agendamento");

            InsertAppointmentResponse insertAppointmentResponse = result;

            return Result.Ok(insertAppointmentResponse);
        }
    }
}
