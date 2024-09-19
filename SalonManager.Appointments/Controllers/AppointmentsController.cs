using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Appointments.CrossCutting.Models;
using SalonManager.Appointments.Features.Appointments.Commands.Delete;
using SalonManager.Appointments.Features.Appointments.Commands.Finish;
using SalonManager.Appointments.Features.Appointments.Commands.Insert;
using SalonManager.Appointments.Features.Appointments.Commands.Update;
using SalonManager.Appointments.Features.Appointments.Commands.UpdateStatus;
using SalonManager.Appointments.Features.Appointments.Queries.Select;
using SalonManager.Appointments.Features.Appointments.Queries.SelectAll;
using SalonManager.Appointments.Features.Appointments.Queries.SelectByCustomerId;
using SalonManager.Appointments.Features.Appointments.Queries.SelectByEmployeeId;
using SalonManager.Appointments.Features.Appointments.Queries.SelectFinishedByDate;

namespace SalonManager.Appointments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : MainController
    {
        public AppointmentsController(IMediator mediator)
                   : base(mediator)
        {
        }

        [Authorize(Roles = "Owner,Employee,Admin,Customer")]
        [HttpGet("{tenantId}/{id}")]
        public async Task<ActionResult<SelectAppointmentResponse>> Select(
            [FromRoute] Guid tenantId,
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAppointmentRequest(id, tenantId), cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpGet("{tenantId}")]
        public async Task<ActionResult<PagedResult<SelectAppointmentResponse>>> SelectAll(
            [FromRoute] Guid tenantId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAllAppointmentsRequest(tenantId, pageNumber, pageSize), cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin,Customer")]
        [HttpGet("customer/{tenantId}/{customerId}")]
        public async Task<ActionResult<SelectAllAppointmentsByCustomerIdResponse>> SelectAllByCustomerId(
            [FromRoute] Guid tenantId, [FromRoute] Guid customerId, CancellationToken cancellationToken)
            => await SendRequest(new SelectAllAppointmentsByCustomerIdRequest(customerId, tenantId), cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpGet("employee/{tenantId}/{employeeId}")]
        public async Task<ActionResult<SelectAllAppointmentsByEmployeeIdResponse>> SelectAllByEmployeeId(
            [FromRoute] Guid tenantId, [FromRoute] Guid employeeId, CancellationToken cancellationToken)
            => await SendRequest(new SelectAllAppointmentsByEmployeeIdRequest(employeeId, tenantId), cancellationToken);

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet("{tenantId}/allFinished/")]
        public async Task<ActionResult<SelectAllAppointmentsFinishedByDateResponse>> SelectAllFinishedByDate(
            [FromRoute] Guid tenantId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAllAppointmentsFinishedByDateRequest(tenantId, startDate, endDate), cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpPost("")]
        public async Task<ActionResult<InsertAppointmentResponse>> Insert(
            [FromBody] InsertAppointmentRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpPut("")]
        public async Task<ActionResult<UpdateAppointmentResponse>> Update(
            [FromBody] UpdateAppointmentRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Admin")]
        [HttpDelete("{tenantId}/{id}")]
        public async Task<ActionResult<DeleteAppointmentResponse>> Delete(
            [FromRoute] Guid tenantId, [FromRoute] Guid id, CancellationToken cancellationToken)
            => await SendRequest(new DeleteAppointmentRequest(id, tenantId), cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpPut("finish")]
        public async Task<ActionResult<FinishAppointmentResponse>> Finish(
        [FromBody] FinishAppointmentRequest request, CancellationToken cancellationToken)
        => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpPatch("update-status")]
        public async Task<ActionResult<UpdateStatusAppointmentResponse>> UpdateStatus(
        [FromBody] UpdateStatusAppointmentRequest request, CancellationToken cancellationToken)
        => await SendRequest(request, cancellationToken);
    }
}
