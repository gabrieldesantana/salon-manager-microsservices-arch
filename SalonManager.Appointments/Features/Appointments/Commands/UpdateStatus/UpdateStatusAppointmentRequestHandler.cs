using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Features.Appointments.Commands.Finish;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Appointments.Features.Appointments.Commands.UpdateStatus
{
    internal class UpdateStatusAppointmentRequestHandler : IRequestHandler<UpdateStatusAppointmentRequest, Result<UpdateStatusAppointmentResponse>>
    {
        private readonly IAppointmentCommandRepository _commandRepository;
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly IValidator<UpdateStatusAppointmentRequest> _validator;
        public UpdateStatusAppointmentRequestHandler(
            IAppointmentCommandRepository commandRepository,
            IAppointmentQueryRepository queryRepository,
            IValidator<UpdateStatusAppointmentRequest> validator)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _validator = validator;
        }
        public async Task<Result<UpdateStatusAppointmentResponse>> Handle(UpdateStatusAppointmentRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointment = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);
            if (appointment == null)
                return Result.Fail<UpdateStatusAppointmentResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o agendamento de ID: {request.Id}");

            appointment.UpdateStatus(request.Status);

            var result = await _commandRepository.UpdateAsync(appointment, request.Id);

            if (result == null)
                return Result.Fail<UpdateStatusAppointmentResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            return Result.Ok(new UpdateStatusAppointmentResponse(appointment.Id, appointment.Status));
        }
    }
}
