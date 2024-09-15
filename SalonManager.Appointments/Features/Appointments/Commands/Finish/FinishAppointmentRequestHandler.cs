using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.CrossCutting.Dtos;
using SalonManager.Appointments.CrossCutting.Requests;
using SalonManager.Appointments.Infrastructure.Refit;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Appointments.Features.Appointments.Commands.Finish
{
    internal class FinishAppointmentRequestHandler : IRequestHandler<FinishAppointmentRequest, Result<FinishAppointmentResponse>>
    {
        private readonly IAppointmentCommandRepository _commandRepository;
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly ICustomerServiceRefit _customerServiceRefit;
        private readonly ISalonServiceServiceRefit _salonServiceServiceRefit;
        private readonly IValidator<FinishAppointmentRequest> _validator;
        public FinishAppointmentRequestHandler(
            IAppointmentCommandRepository commandRepository,
            IAppointmentQueryRepository queryRepository,
            ICustomerServiceRefit customerServiceRefit,
            ISalonServiceServiceRefit salonServiceServiceRefit,
            IValidator<FinishAppointmentRequest> validator)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _customerServiceRefit = customerServiceRefit;
            _salonServiceServiceRefit = salonServiceServiceRefit;
            _validator = validator;
        }
        public async Task<Result<FinishAppointmentResponse>> Handle(FinishAppointmentRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointment = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);
            appointment.AppointmentDate = DateTime.SpecifyKind(appointment.AppointmentDate, DateTimeKind.Unspecified);

            if (appointment == null)
                return Result.Fail<FinishAppointmentResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o agendamento de ID: {request.Id}");

            appointment.Finish(request.PaymentMethod, request.PaymentWay, request.Earnings, request.Details);

            var result = await _commandRepository.UpdateAsync(appointment, appointment.TenantId);
            if (result == null)
                return Result.Fail<FinishAppointmentResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            var serviceResult = await _salonServiceServiceRefit.GetSalonServiceAsync(request.TenantId, appointment.ServiceAppointmentId);

            if (!serviceResult.IsSuccessStatusCode || serviceResult.Content == null)
                return Result.Fail<FinishAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel localizar o servico");

            var increaseVisitedTimesRequest = new IncreaseVisitedTimesRequest()
            {
                Id = appointment.CustomerAppointmentId,
                TenantId = appointment.TenantId,
                LastServiceDate = appointment.AppointmentDate,
                LastServiceName = serviceResult.Content.Name!
            };

            var customerResult = await _customerServiceRefit.IncreaseVisitedTimes(increaseVisitedTimesRequest);
            if (!customerResult.IsSuccessStatusCode || customerResult.Content == null)
                return Result.Fail<FinishAppointmentResponse>($"{nameof(ApiException)}|Nao foi possivel registrar a visita do cliente");

            return Result.Ok(new FinishAppointmentResponse(request.Id));
        }
    }
}
