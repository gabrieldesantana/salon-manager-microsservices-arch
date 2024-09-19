using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Features.Appointments.Commands.Finish;
using SalonManager.Appointments.Infrastructure.Refit;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectFinishedByDate
{
    internal class SelectAllAppointmentsFinishedByDateRequestHandler : IRequestHandler<SelectAllAppointmentsFinishedByDateRequest, Result<SelectAllAppointmentsFinishedByDateResponse>>
    {
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly ICustomerServiceRefit _customerServiceRefit;
        private readonly IEmployeeServiceRefit _employeeServiceRefit;
        private readonly ISalonServiceServiceRefit _salonServiceServiceRefit;
        private readonly IValidator<SelectAllAppointmentsFinishedByDateRequest> _validator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SelectAllAppointmentsFinishedByDateRequestHandler(
            IAppointmentQueryRepository queryRepository,
            ICustomerServiceRefit customerServiceRefit,
            IEmployeeServiceRefit employeeServiceRefit,
            ISalonServiceServiceRefit salonServiceServiceRefit,
            IHttpContextAccessor httpContextAccessor,
            IValidator<SelectAllAppointmentsFinishedByDateRequest> validator)
            => (_queryRepository, _customerServiceRefit, _employeeServiceRefit, _salonServiceServiceRefit, _httpContextAccessor, _validator) 
            = (queryRepository, customerServiceRefit, employeeServiceRefit, salonServiceServiceRefit, httpContextAccessor, validator);

        public async Task<Result<SelectAllAppointmentsFinishedByDateResponse>> Handle(SelectAllAppointmentsFinishedByDateRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointmnets = await _queryRepository.GetAllFinishedByDateAsync(request.TenantId, request.StartDate, request.EndDate);


            var authorizationHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"];
            if (!authorizationHeader.ToString().StartsWith("Bearer"))
            {
                return Result.Fail<SelectAllAppointmentsFinishedByDateResponse>($"{nameof(UnauthorizedException)}|Nao foi possivel resgatar o token");
            }
            var token = authorizationHeader.ToString();

            foreach (var appointment in appointmnets)
            {
                var resultCustomer = await _customerServiceRefit.GetCustomerAsync(token, appointment.TenantId, appointment.CustomerAppointmentId);
                if (!resultCustomer.IsSuccessStatusCode || resultCustomer.Content == null)
                    return Result.Fail<SelectAllAppointmentsFinishedByDateResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o cliente de ID: {appointment.CustomerAppointmentId}");

                appointment.CustomerAppointment = resultCustomer.Content;

                var resultEmployee = await _employeeServiceRefit.GetEmployeeAsync(token, appointment.TenantId, appointment.EmployeeAppointmentId);
                if (!resultEmployee.IsSuccessStatusCode || resultEmployee.Content == null)
                    return Result.Fail<SelectAllAppointmentsFinishedByDateResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o empregado de ID: {appointment.EmployeeAppointmentId}");

                appointment.EmployeeAppointment = resultEmployee.Content;

                var resultService = await _salonServiceServiceRefit.GetSalonServiceAsync(token, appointment.TenantId, appointment.ServiceAppointmentId);
                if (!resultService.IsSuccessStatusCode || resultService.Content == null)
                    return Result.Fail<SelectAllAppointmentsFinishedByDateResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o servico de ID: {appointment.ServiceAppointmentId}");

                appointment.ServiceAppointment = resultService.Content;
            }

            SelectAllAppointmentsFinishedByDateResponse selectAllAppointmentsFinishedByDateResponse = new(
                appointmnets,
                appointmnets.Sum(x => x.Earnings),
                request.StartDate,
                request.EndDate,
                request.StartDate.ToString("dd/MM/yyyy"),
                request.EndDate.ToString("dd/MM/yyyy")
                );

            return Result.Ok(selectAllAppointmentsFinishedByDateResponse);
        }
    }
}
