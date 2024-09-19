using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Infrastructure.Refit;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Appointments.Features.Appointments.Queries.Select
{
    internal class SelectAppointmentRequestHandler : IRequestHandler<SelectAppointmentRequest, Result<SelectAppointmentResponse>>
    {
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly IValidator<SelectAppointmentRequest> _validator;

        private readonly ICustomerServiceRefit _customerServiceRefit;
        private readonly ISalonServiceServiceRefit _salonServiceServiceRefit;
        private readonly IEmployeeServiceRefit _employeeServiceRefit;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SelectAppointmentRequestHandler(
            IAppointmentQueryRepository queryRepository,
            ICustomerServiceRefit customerServiceRefit,
        ISalonServiceServiceRefit salonServiceServiceRefit,
        IEmployeeServiceRefit employeeServiceRefit,
        IHttpContextAccessor httpContextAccessor,
        IValidator<SelectAppointmentRequest> validator)
        {
            _validator = validator;
            _queryRepository = queryRepository;
            _customerServiceRefit = customerServiceRefit;
            _salonServiceServiceRefit = salonServiceServiceRefit;
            _employeeServiceRefit = employeeServiceRefit;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result<SelectAppointmentResponse>> Handle(SelectAppointmentRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            Appointment appointment = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            var authorizationHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"];
            if (!authorizationHeader.ToString().StartsWith("Bearer"))
            {
                return Result.Fail<SelectAppointmentResponse>($"{nameof(UnauthorizedException)}|Nao foi possivel resgatar o token");
            }
            var token = authorizationHeader.ToString();

            if (appointment == null)
                return Result.Fail<SelectAppointmentResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o agendamento de ID: {request.Id}");

            var customerResult = await _customerServiceRefit.GetCustomerAsync(token, request.TenantId, appointment.CustomerAppointmentId);

            if (!customerResult.IsSuccessStatusCode || customerResult.Content == null)
                return Result.Fail<SelectAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel obter o cliente");

            var salonServiceResult = await _salonServiceServiceRefit.GetSalonServiceAsync(token, request.TenantId, appointment.ServiceAppointmentId);

            if (!salonServiceResult.IsSuccessStatusCode || salonServiceResult.Content == null)
                return Result.Fail<SelectAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel obter o servico");

            var employeeResult = await _employeeServiceRefit.GetEmployeeAsync(token, request.TenantId, appointment.EmployeeAppointmentId);

            if (!employeeResult.IsSuccessStatusCode || employeeResult.Content == null)
                return Result.Fail<SelectAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel obter o empregado");

            appointment.CustomerAppointment = customerResult.Content;
            appointment.ServiceAppointment = salonServiceResult.Content;
            appointment.EmployeeAppointment = employeeResult.Content;

            SelectAppointmentResponse selectAppointmentResponse = appointment;

            return Result.Ok(selectAppointmentResponse);
        }
    }
}
