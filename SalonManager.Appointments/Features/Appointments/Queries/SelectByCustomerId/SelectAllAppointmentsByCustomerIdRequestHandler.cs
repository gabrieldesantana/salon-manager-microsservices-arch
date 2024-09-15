using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Appointments.Core.Interfaces.Repositories;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectByCustomerId
{
    internal class SelectAllAppointmentsByCustomerIdRequestHandler : IRequestHandler<SelectAllAppointmentsByCustomerIdRequest, Result<SelectAllAppointmentsByCustomerIdResponse>>
    {
        private readonly IAppointmentQueryRepository _queryRepository;
        private readonly IValidator<SelectAllAppointmentsByCustomerIdRequest> _validator;
        public SelectAllAppointmentsByCustomerIdRequestHandler(IAppointmentQueryRepository queryRepository, IValidator<SelectAllAppointmentsByCustomerIdRequest> validator)
        {
            _queryRepository = queryRepository;
            _validator = validator;
        }
        public async Task<Result<SelectAllAppointmentsByCustomerIdResponse>> Handle(SelectAllAppointmentsByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var appointments = await _queryRepository.GetAllByCustomerIdAsync(request.CustomerId, request.TenantId);
            return Result.Ok(new SelectAllAppointmentsByCustomerIdResponse(appointments));
        }
    }
}
