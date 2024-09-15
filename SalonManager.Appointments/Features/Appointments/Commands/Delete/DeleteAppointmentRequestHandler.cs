using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Appointments.Features.Appointments.Commands.Delete
{
    internal class DeleteAppointmentRequestHandler : IRequestHandler<DeleteAppointmentRequest, Result<DeleteAppointmentResponse>>
    {
        private readonly IAppointmentCommandRepository _commandRepository;
        private readonly IValidator<DeleteAppointmentRequest> _validator;
        public DeleteAppointmentRequestHandler(IAppointmentCommandRepository commandRepository, IValidator<DeleteAppointmentRequest> validator)
            => (_commandRepository, _validator) = (commandRepository, validator);

        public async Task<Result<DeleteAppointmentResponse>> Handle(DeleteAppointmentRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            bool status = await _commandRepository.DeleteAsync(request.Id, request.TenantId);
            if (status)
                return Result.Fail<DeleteAppointmentResponse>($"{nameof(BadRequestException)}|Nao foi possivel excluir o agendamento de ID: {request.Id}");

            return Result.Ok(new DeleteAppointmentResponse(request.Id, status));
        }
    }
}
