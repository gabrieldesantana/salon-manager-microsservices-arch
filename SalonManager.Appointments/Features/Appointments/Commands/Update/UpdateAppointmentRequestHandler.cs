using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Features.Appointments.Commands.Finish;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Appointments.Features.Appointments.Commands.Update
{
    internal class UpdateAppointmentRequestHandler : IRequestHandler<UpdateAppointmentRequest, Result<UpdateAppointmentResponse>>
    {
        private readonly IAppointmentCommandRepository _commandRepository;
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly IValidator<UpdateAppointmentRequest> _validator;
        public UpdateAppointmentRequestHandler(
            IAppointmentCommandRepository commandRepository,
            IAppointmentQueryRepository queryRepository,
            IValidator<UpdateAppointmentRequest> validator)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _validator = validator;
        }
        public async Task<Result<UpdateAppointmentResponse>> Handle(UpdateAppointmentRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointment = await _commandRepository.GetByIdAsync(request.Id, request.TenantId);

            if (appointment == null)
                return Result.Fail<UpdateAppointmentResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o agendamento de ID: {request.Id}");

            appointment.Update(
                request.AppointmentDate,
                request.Details
                );

            var result = await _commandRepository.UpdateAsync(appointment, request.Id);
            if (result == null)
                return Result.Fail<UpdateAppointmentResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            UpdateAppointmentResponse updateAppointmentResponse = appointment;

            return Result.Ok(updateAppointmentResponse);
        }
    }
}
