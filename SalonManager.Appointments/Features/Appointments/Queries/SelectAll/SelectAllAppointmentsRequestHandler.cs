using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.CrossCutting.Models;
using SalonManager.Appointments.Features.Appointments.Queries.Select;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectAll
{

    internal class SelectAllAppointmentsRequestHandler : IRequestHandler<SelectAllAppointmentsRequest, Result<PagedResult<SelectAppointmentResponse>>>
    {
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly IAppointmentCommandRepository _commandRepository;
        private readonly IValidator<SelectAllAppointmentsRequest> _validator;
        public SelectAllAppointmentsRequestHandler(IAppointmentQueryRepository queryRepository, IAppointmentCommandRepository commandRepository, IValidator<SelectAllAppointmentsRequest> validator)
        => (_queryRepository, _commandRepository, _validator) = (queryRepository, commandRepository , validator);
        
        public async Task<Result<PagedResult<SelectAppointmentResponse>>> Handle(SelectAllAppointmentsRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointments = await _queryRepository.GetAllAsync(request.TenantId, request.PageNumber, request.PageSize);
            var totalAppointments = await _commandRepository.CountAsync(request.TenantId);

            return Result.Ok(SelectAllAppointmentsResponse.FromAppointmentsToPagedResult(appointments, request.PageNumber, request.PageSize, totalAppointments));
        }
    }
}
