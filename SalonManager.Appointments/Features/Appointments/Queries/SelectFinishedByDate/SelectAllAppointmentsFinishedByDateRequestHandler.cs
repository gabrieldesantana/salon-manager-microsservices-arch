using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectFinishedByDate
{
    internal class SelectAllAppointmentsFinishedByDateRequestHandler : IRequestHandler<SelectAllAppointmentsFinishedByDateRequest, Result<SelectAllAppointmentsFinishedByDateResponse>>
    {
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly IValidator<SelectAllAppointmentsFinishedByDateRequest> _validator;
        public SelectAllAppointmentsFinishedByDateRequestHandler(IAppointmentQueryRepository queryRepository, IValidator<SelectAllAppointmentsFinishedByDateRequest> validator)
            => (_queryRepository, _validator) = (queryRepository, validator);
        public async Task<Result<SelectAllAppointmentsFinishedByDateResponse>> Handle(SelectAllAppointmentsFinishedByDateRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointmnets = await _queryRepository.GetAllFinishedByDateAsync(request.TenantId, request.StartDate, request.EndDate);

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
