using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;
using SalonManager.Business.Features.Employees.Commands.Insert;
using SalonManager.Business.Infrastructure.Refit;

namespace SalonManager.Business.Features.Employees.Queries.Select
{
    internal class SelectEmployeeRequestHandler : IRequestHandler<SelectEmployeeRequest, Result<SelectEmployeeResponse>>
    {
        private readonly IEmployeeQueryRepository _queryRepository;
        private readonly IAppointmentServiceRefit _appointmentServiceRefit;
        private readonly IValidator<SelectEmployeeRequest> _validator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SelectEmployeeRequestHandler(
            IEmployeeQueryRepository queryRepository,
            IAppointmentServiceRefit appointmentServiceRefit,
            IValidator<SelectEmployeeRequest> validator,
            IHttpContextAccessor httpContextAccessor
            )
            => (_queryRepository, _appointmentServiceRefit, _validator, _httpContextAccessor) = (queryRepository, appointmentServiceRefit, validator, httpContextAccessor);

        public async Task<Result<SelectEmployeeResponse>> Handle(SelectEmployeeRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var employee = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (employee == null)
                return Result.Fail<SelectEmployeeResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o empregado de ID: {request.Id}");

            var authorizationHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"];
            if (!authorizationHeader.ToString().StartsWith("Bearer"))
            {
                return Result.Fail<SelectEmployeeResponse>($"{nameof(UnauthorizedException)}|Nao foi possivel resgatar o token");
            }
            var token = authorizationHeader.ToString();

            var appointmentsByEmployeeResult = await _appointmentServiceRefit.GetAppointmentsByEmployeeAsync(token, request.TenantId, request.Id);

            if (!appointmentsByEmployeeResult.IsSuccessStatusCode || appointmentsByEmployeeResult.Content == null)
                return Result.Fail<SelectEmployeeResponse>($"{nameof(ApiException)}|Nao foi possivel obter o cliente");

            employee.Appointments = appointmentsByEmployeeResult.Content.Appointments;

            SelectEmployeeResponse selectEmployeeResponse = employee;
            return Result.Ok(selectEmployeeResponse);
        }
    }
}
