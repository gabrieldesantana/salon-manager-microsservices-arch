using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectByEmployeeId
{
    internal class SelectAllAppointmentsByEmployeeIdRequestHandler : IRequestHandler<SelectAllAppointmentsByEmployeeIdRequest, Result<SelectAllAppointmentsByEmployeeIdResponse>>
    {
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly IValidator<SelectAllAppointmentsByEmployeeIdRequest> _validator;
        public SelectAllAppointmentsByEmployeeIdRequestHandler(IAppointmentQueryRepository queryRepository, IValidator<SelectAllAppointmentsByEmployeeIdRequest> validator)
        {
            _queryRepository = queryRepository;
            _validator = validator;
        }
        public async Task<Result<SelectAllAppointmentsByEmployeeIdResponse>> Handle(SelectAllAppointmentsByEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointments = await _queryRepository.GetAllByEmployeeIdAsync(request.EmployeeId, request.TenantId);
            return Result.Ok(new SelectAllAppointmentsByEmployeeIdResponse(appointments));
        }
    }
}
